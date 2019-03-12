﻿using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using CyberSource.Api;
using CybsQaScript.Csv_HelperClasses;
using LumenWorks.Framework.IO.Csv;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace CybsQaScript.Reporting.CoreServices
{
    public class DownloadReport
    {
    public static void DownloadRepExec()
    {
        // Initialize Api Name
        var apiFunctionName = "DownloadReport";

        // To Load the previous Data in the output file---
        var dataAppend = new DataAppend();
        var recordsPrev = dataAppend.ReadPrevData();

        // Reading the CSV input file
        using (var csv =
            new CsvReader(new StreamReader(@"../../CSV_Files/Reporting/CoreServices/DownloadReport.csv"), true))
        {
            var fieldCount = csv.FieldCount;

            // Writing  to output CSV file
            using (var writer = new CsvFileWriter(@"../../CSV_Files/TestReport/TestResults.csv"))
            {
                var flag = 0;
                var headers = csv.GetFieldHeaders();

                while (csv.ReadNextRecord())
                {
                        // Read Input Csv File
                    string orgId = null;
                    string repName = null;
                    string repDate = null;
                    string testCaseId = null;
                    string message = null;

                    // TestResults csv file fields
                        var resultStatus = string.Empty;
                        var resultMessage = string.Empty;

                        for (int i = 0; i < fieldCount; i++)
                        {
                        switch (headers[i])
                        {
                            case "testCaseId":
                                testCaseId = csv[i];
                                break;
                            case "orgId":
                                    orgId = csv[i];
                                break;
                                case "repName":
                                    repName = csv[i];
                                    break;
                                case "repDate":
                                    repDate = csv[i];
                                    break;
                                case "message":
                                message = csv[i];
                                break;
                        }
                    }

                        string reportDate = repDate;
                        string reportName = repName;
                        string organizationId = orgId;

                        // Write to output file
                        var row = new CsvRow();

                    // Intialize Api Configuration and client configuration
                    var configDictionary = new Configuration().GetConfiguration();
                    var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                    try
                    {
                            if (flag == 0)
                            {
                                row.Add("TestCaseId");
                                row.Add("APIName");
                                row.Add("Status");
                                row.Add("Message");
                                row.Add("TimeStamp");
                                writer.WriteRow(row);

                                // Write previous records
                                foreach (var item in recordsPrev)
                                {
                                    var rowPrev = new CsvRow
                                    {
                                        item.TestCaseId,
                                        item.APIName,
                                        item.Status,
                                        item.Message,
                                        item.TimeStamp
                                    };
                                    writer.WriteRow(rowPrev);
                                }

                                flag = flag + 1;
                            }

                            var apiInstance = new ReportDownloadsApi(clientConfig);

                            var response = apiInstance.DownloadReportWithHttpInfo(reportDate, reportName, organizationId);

                            if (response == null)
                            {
                                resultStatus = $"Assertion Failed: {clientConfig.ApiClient.ApiResponse.StatusCode}";
                                resultMessage = "response is null";
                            }
                            else
                            {
                                resultStatus = $"Pass:{clientConfig.ApiClient.ApiResponse.StatusCode}";
                                resultMessage = "Success";
                            }
                        }
                        catch (Exception e)
                        {
                            resultStatus = $"Fail:{clientConfig.ApiClient.ApiResponse.StatusCode}";

                            var xmlResponseBody = e.GetType().GetProperty("ErrorContent").GetValue(e);
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(xmlResponseBody.ToString());

                            var jsonResponseBody = JsonConvert.SerializeXmlNode(doc);
                            var jsonObj = JObject.Parse(jsonResponseBody.ToString());
                            var reasonInResponseBody = (string)jsonObj["errorBean"]["message"];
                            resultMessage = reasonInResponseBody;
                        }
                        finally
                        {
                            if (resultStatus == null)
                            {
                                resultStatus = string.Empty;
                            }

                            if (resultMessage == null)
                            {
                                resultMessage = string.Empty;
                            }

                            var row1 = new CsvRow
                                        {
                                          testCaseId,
                                          apiFunctionName,
                                          resultStatus,
                                          resultMessage,
                                          Constants.DateTimeNow
                                        };

                            writer.WriteRow(row1);
                            flag = flag + 1;
                        }
                    }
                }
            }
        }
    }
}