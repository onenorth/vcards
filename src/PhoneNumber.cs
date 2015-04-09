// <copyright file="phonenumber.cs" company="One North Interactive">
// PhoneNumber
// </copyright>

namespace OneNorth.VCards
{
    using System;
    using System.Text;

    /// <summary>
    /// Represents a phone number.
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// Phone number type.
        /// </summary>
        private PhoneNumberTypes _phoneNumberType = PhoneNumberTypes.WORK;

        /// <summary>
        /// Phone number.
        /// </summary>
        private string _number = string.Empty;            

        /// <summary>
        /// Gets or sets the phone number digits/alpha characters.
        /// </summary>
        public string Number
        {
            get { return _number; }
            set { _number = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets or sets the phone number type.
        /// </summary>
        public PhoneNumberTypes PhoneNumberType
        {
            get { return _phoneNumberType; }
            set { _phoneNumberType = value; }
        }

        /// <summary>
        /// Converts phone number to string.
        /// </summary>
        /// <returns>Phone number in string format.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(string.Concat("TEL;", PhoneNumberType == PhoneNumberTypes.FAX ? "WORK;" : string.Empty, Enum.GetName(typeof(PhoneNumberTypes), PhoneNumberType), ":"));
            sb.Append(string.Concat(PropertyValueEncoder.GetEncodedPropertyValue(_number, false), "\r\n"));
            return sb.ToString();
        }
    }
}