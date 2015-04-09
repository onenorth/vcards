// <copyright file="vcard.cs" company="One North Interactive">
// VCard
// </copyright>

namespace OneNorth.VCards
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Represents a vCard.
    /// </summary>
    public class VCard
    {
        /// <summary>
        /// Character set.
        /// </summary>
        private string _characterSet = "utf-8";

        /// <summary>
        /// Formatted name.
        /// </summary>
        private string _formattedName = string.Empty;

        /// <summary>
        /// Last name.
        /// </summary>
        private string _lastName = string.Empty;

        /// <summary>
        /// First name.
        /// </summary>
        private string _firstName = string.Empty;

        /// <summary>
        /// Middle name.
        /// </summary>
        private string _middleName = string.Empty;

        /// <summary>
        /// Name prefix.
        /// </summary>
        private string _namePrefix = string.Empty;

        /// <summary>
        /// Name suffix.
        /// </summary>
        private string _nameSuffix = string.Empty;

        /// <summary>
        /// Birth date.
        /// </summary>
        private DateTime _birthDate = DateTime.MinValue;

        /// <summary>
        /// Address list.
        /// </summary>
        private readonly List<DeliveryAddress> _addresses = new List<DeliveryAddress>();

        /// <summary>
        /// Phone number list.
        /// </summary>
        private readonly List<PhoneNumber> _phoneNumbers = new List<PhoneNumber>();

        /// <summary>
        /// Email address list.
        /// </summary>
        private readonly List<string> _emailAddresses = new List<string>();

        /// <summary>
        /// Individual's title.
        /// </summary>
        private string _title = string.Empty;

        /// <summary>
        /// Individual's role.
        /// </summary>
        private string _role = string.Empty;

        /// <summary>
        /// Individual's organization.
        /// </summary>
        private string _organization = string.Empty;

        /// <summary>
        /// Individual's URL.
        /// </summary>
        private string _url = string.Empty;

        /// <summary>
        /// Individual's note.
        /// </summary>
        private string _note = string.Empty;

        /// <summary>
        /// Character set.
        /// </summary>
        public string CharacterSet
        {
            get { return _characterSet; }
            set { _characterSet = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets or sets formatted name.
        /// </summary>
        public string FormattedName
        {
            get { return _formattedName; }
            set { _formattedName = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets or sets last name.
        /// </summary>
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets or sets first name.
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets or sets middle name.
        /// </summary>
        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets or sets name prefix.
        /// </summary>
        public string NamePrefix
        {
            get { return _namePrefix; }
            set { _namePrefix = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets or sets name suffix.
        /// </summary>
        public string NameSuffix
        {
            get { return _nameSuffix; }
            set { _nameSuffix = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets or sets birth date.
        /// </summary>
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        /// <summary>
        /// Gets addresses.
        /// </summary>
        public List<DeliveryAddress> Addresses
        {
            get { return _addresses; }            
        }

        /// <summary>
        /// Gets phone numbers.
        /// </summary>
        public List<PhoneNumber> PhoneNumbers
        {
            get { return _phoneNumbers; }
        }

        /// <summary>
        /// Gets email addresses.
        /// </summary>
        public List<string> EmailAddresses
        {
            get { return _emailAddresses; }            
        }

        /// <summary>
        /// Gets or sets title.
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets or sets role.
        /// </summary>
        public string Role
        {
            get { return _role; }
            set { _role = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets or sets organization.
        /// </summary>
        public string Organization
        {
            get { return _organization; }
            set { _organization = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets or sets URL.
        /// </summary>
        public string Url
        {
            get { return _url; }
            set { _url = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets or sets note.
        /// </summary>
        public string Note
        {
            get { return _note; }
            set { _note = value ?? string.Empty; }
        }

        /// <summary>
        /// Generate vCard.
        /// </summary>
        /// <param name="outputStream">Output stream.</param>
        public void Generate(Stream outputStream)
        {
            using (var sw = new StreamWriter(outputStream))
            {
                sw.Write(ToString());
            }
        }

        /// <summary>
        /// Generate vCard.
        /// </summary>
        /// <param name="outputStream">Output stream.</param>
        /// <param name="encoding"></param>
        public void Generate(Stream outputStream, Encoding encoding)
        {
            using (var sw = new StreamWriter(outputStream, encoding))
            {
                sw.Write(ToString());
            }
        }

        /// <summary>
        /// Convert vCard to string.
        /// </summary>
        /// <returns>Formatted vCard string.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            string characterSetModifier = _characterSet.Length > 0 ? string.Format(";CHARSET={0}", _characterSet) : string.Empty;
            
            sb.Append("BEGIN:VCARD\r\n");
            
            if (_formattedName != null)
            {
                sb.Append(string.Concat("FN:", PropertyValueEncoder.GetEncodedPropertyValue(_formattedName, false), "\r\n"));
            }

            sb.Append(string.Concat("N", characterSetModifier, ":", PropertyValueEncoder.GetEncodedPropertyValue(_lastName, false), ";"));
            sb.Append(string.Concat(PropertyValueEncoder.GetEncodedPropertyValue(_firstName, false), ";"));
            sb.Append(string.Concat(PropertyValueEncoder.GetEncodedPropertyValue(_middleName, false), ";"));
            sb.Append(string.Concat(PropertyValueEncoder.GetEncodedPropertyValue(_namePrefix, false), ";"));
            sb.Append(string.Concat(PropertyValueEncoder.GetEncodedPropertyValue(_nameSuffix, false), "\r\n"));
            
            if (_birthDate != DateTime.MinValue)
            {
                sb.Append(string.Concat("BDAY:", PropertyValueEncoder.GetEncodedPropertyValue(_birthDate.ToString("yyyyMMdd"), false), "\r\n"));
            }
            
            foreach (var da in _addresses)
            {
                da.CharacterSet = CharacterSet;
                sb.Append(da);
            }
            
            foreach (var phone in _phoneNumbers)
            {
                sb.Append(phone);
            }
            
            foreach (var email in _emailAddresses)
            {
                if (!string.IsNullOrEmpty(email))
                {
                    sb.Append(string.Concat("EMAIL", characterSetModifier, "; INTERNET:", PropertyValueEncoder.GetEncodedPropertyValue(email, false), "\r\n"));
                }
            }

            sb.Append(string.Concat("TITLE", characterSetModifier, ";ENCODING=QUOTED-PRINTABLE", ":", PropertyValueEncoder.GetEncodedPropertyValue(_title, true), "\r\n"));
            sb.Append(string.Concat("ROLE", characterSetModifier, ":", PropertyValueEncoder.GetEncodedPropertyValue(_role, false), "\r\n"));
            sb.Append(string.Concat("ORG", characterSetModifier, ":", PropertyValueEncoder.GetEncodedPropertyValue(_organization, false), "\r\n"));

            if (!string.IsNullOrEmpty(_note))
            {
                sb.Append(string.Concat("NOTE", characterSetModifier, ";ENCODING=QUOTED-PRINTABLE", ":", PropertyValueEncoder.GetEncodedPropertyValue(_note, true), "\r\n"));
            }

            if (!string.IsNullOrEmpty(_url))
            {
                sb.Append(string.Concat("URL; WORK", characterSetModifier, ":", PropertyValueEncoder.GetEncodedPropertyValue(_url, false), "\r\n"));
            }

            sb.Append("END:VCARD\r\n");

            return sb.ToString();
        }        
    }
}