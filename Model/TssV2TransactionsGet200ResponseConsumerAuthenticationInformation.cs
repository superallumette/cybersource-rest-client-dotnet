/* 
 * CyberSource Merged Spec
 *
 * All CyberSource API specs merged together. These are available at https://developer.cybersource.com/api/reference/api-reference.html
 *
 * OpenAPI spec version: 0.0.1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = CyberSource.Client.SwaggerDateConverter;

namespace CyberSource.Model
{
    /// <summary>
    /// TssV2TransactionsGet200ResponseConsumerAuthenticationInformation
    /// </summary>
    [DataContract]
    public partial class TssV2TransactionsGet200ResponseConsumerAuthenticationInformation :  IEquatable<TssV2TransactionsGet200ResponseConsumerAuthenticationInformation>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TssV2TransactionsGet200ResponseConsumerAuthenticationInformation" /> class.
        /// </summary>
        /// <param name="EciRaw">Raw electronic commerce indicator (ECI). For the description and requirements, see \&quot;Payer Authentication,\&quot; page 180..</param>
        /// <param name="Cavv">Cardholder authentication verification value (CAVV)..</param>
        /// <param name="Xid">Transaction identifier. For the description and requirements, see \&quot;Payer Authentication,\&quot; page 180..</param>
        /// <param name="TransactionId">Payer auth Transaction identifier..</param>
        public TssV2TransactionsGet200ResponseConsumerAuthenticationInformation(string EciRaw = default(string), string Cavv = default(string), string Xid = default(string), string TransactionId = default(string))
        {
            this.EciRaw = EciRaw;
            this.Cavv = Cavv;
            this.Xid = Xid;
            this.TransactionId = TransactionId;
        }
        
        /// <summary>
        /// Raw electronic commerce indicator (ECI). For the description and requirements, see \&quot;Payer Authentication,\&quot; page 180.
        /// </summary>
        /// <value>Raw electronic commerce indicator (ECI). For the description and requirements, see \&quot;Payer Authentication,\&quot; page 180.</value>
        [DataMember(Name="eciRaw", EmitDefaultValue=false)]
        public string EciRaw { get; set; }

        /// <summary>
        /// Cardholder authentication verification value (CAVV).
        /// </summary>
        /// <value>Cardholder authentication verification value (CAVV).</value>
        [DataMember(Name="cavv", EmitDefaultValue=false)]
        public string Cavv { get; set; }

        /// <summary>
        /// Transaction identifier. For the description and requirements, see \&quot;Payer Authentication,\&quot; page 180.
        /// </summary>
        /// <value>Transaction identifier. For the description and requirements, see \&quot;Payer Authentication,\&quot; page 180.</value>
        [DataMember(Name="xid", EmitDefaultValue=false)]
        public string Xid { get; set; }

        /// <summary>
        /// Payer auth Transaction identifier.
        /// </summary>
        /// <value>Payer auth Transaction identifier.</value>
        [DataMember(Name="transactionId", EmitDefaultValue=false)]
        public string TransactionId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TssV2TransactionsGet200ResponseConsumerAuthenticationInformation {\n");
            sb.Append("  EciRaw: ").Append(EciRaw).Append("\n");
            sb.Append("  Cavv: ").Append(Cavv).Append("\n");
            sb.Append("  Xid: ").Append(Xid).Append("\n");
            sb.Append("  TransactionId: ").Append(TransactionId).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as TssV2TransactionsGet200ResponseConsumerAuthenticationInformation);
        }

        /// <summary>
        /// Returns true if TssV2TransactionsGet200ResponseConsumerAuthenticationInformation instances are equal
        /// </summary>
        /// <param name="other">Instance of TssV2TransactionsGet200ResponseConsumerAuthenticationInformation to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TssV2TransactionsGet200ResponseConsumerAuthenticationInformation other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.EciRaw == other.EciRaw ||
                    this.EciRaw != null &&
                    this.EciRaw.Equals(other.EciRaw)
                ) && 
                (
                    this.Cavv == other.Cavv ||
                    this.Cavv != null &&
                    this.Cavv.Equals(other.Cavv)
                ) && 
                (
                    this.Xid == other.Xid ||
                    this.Xid != null &&
                    this.Xid.Equals(other.Xid)
                ) && 
                (
                    this.TransactionId == other.TransactionId ||
                    this.TransactionId != null &&
                    this.TransactionId.Equals(other.TransactionId)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                if (this.EciRaw != null)
                    hash = hash * 59 + this.EciRaw.GetHashCode();
                if (this.Cavv != null)
                    hash = hash * 59 + this.Cavv.GetHashCode();
                if (this.Xid != null)
                    hash = hash * 59 + this.Xid.GetHashCode();
                if (this.TransactionId != null)
                    hash = hash * 59 + this.TransactionId.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            // EciRaw (string) maxLength
            if(this.EciRaw != null && this.EciRaw.Length > 2)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for EciRaw, length must be less than 2.", new [] { "EciRaw" });
            }

            // Cavv (string) maxLength
            if(this.Cavv != null && this.Cavv.Length > 40)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Cavv, length must be less than 40.", new [] { "Cavv" });
            }

            // Xid (string) maxLength
            if(this.Xid != null && this.Xid.Length > 40)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Xid, length must be less than 40.", new [] { "Xid" });
            }

            yield break;
        }
    }

}
