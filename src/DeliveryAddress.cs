// <copyright file="deliveryaddress.cs" company="One North Interactive">
// DeliveryAddress
// </copyright>

namespace OneNorth.VCards
{
    using System;
    using System.Text;

    /// <summary>
    /// Delivery address.
    /// </summary>
    public class DeliveryAddress
    {
        /// <summary>
        /// Delivery address type.
        /// </summary>
        private AddressTypes _deliveryAddressType = AddressTypes.WORK;

        /// <summary>
        /// Character set.
        /// </summary>
        private string _characterSet = string.Empty;

        /// <summary>
        /// Post office address.
        /// </summary>
        private string _postOfficeAddress = string.Empty;

        /// <summary>
        /// Extended address.
        /// </summary>
        private string _extendedAddress = string.Empty;

        /// <summary>
        /// Address street.
        /// </summary>
        private string _street = string.Empty;

        /// <summary>
        /// Address locality/city.
        /// </summary>
        private string _locality = string.Empty;

        /// <summary>
        /// Address region.
        /// </summary>
        private string _region = string.Empty;

        /// <summary>
        /// Address postal code.
        /// </summary>
        private string _postalCode = string.Empty;

        /// <summary>
        /// Address country.
        /// </summary>
        private string _country = string.Empty;

        /// <summary>
        /// Character set.
        /// </summary>
        internal string CharacterSet
        {
            get { return _characterSet; }
            set { _characterSet = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets or sets delivery address type.
        /// </summary>
        public AddressTypes DeliveryAddressType
        {
            get { return _deliveryAddressType; }
            set { _deliveryAddressType = value; }
        }

        /// <summary>
        /// Gets or sets post office address.
        /// </summary>
        public string PostOfficeAddress
        {
            get { return _postOfficeAddress; }
            set { _postOfficeAddress = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets or sets extended address.
        /// </summary>
        public string ExtendedAddress
        {
            get { return _extendedAddress; }
            set { _extendedAddress = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets or sets street.
        /// </summary>
        public string Street
        {
            get { return _street; }
            set { _street = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets or sets locality.
        /// </summary>
        public string Locality
        {
            get { return _locality; }
            set { _locality = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets or sets region.
        /// </summary>
        public string Region
        {
            get { return _region; }
            set { _region = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets or sets postal code.
        /// </summary>
        public string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets or sets country.
        /// </summary>
        public string Country
        {
            get { return _country; }
            set { _country = value ?? string.Empty; }
        }

        /// <summary>
        /// Convert delivery address to a string.
        /// </summary>
        /// <returns>Resulting string.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            var characterSetModifier = _characterSet.Length > 0 ? string.Format(";CHARSET={0}", _characterSet) : string.Empty;

            sb.Append(string.Concat("ADR", characterSetModifier, ";", "ENCODING=QUOTED-PRINTABLE;", Enum.GetName(typeof(AddressTypes), _deliveryAddressType), ":"));
            sb.Append(string.Concat(PropertyValueEncoder.GetEncodedPropertyValue(_postOfficeAddress, true), ";"));
            sb.Append(string.Concat(PropertyValueEncoder.GetEncodedPropertyValue(_extendedAddress, true), ";"));
            sb.Append(string.Concat(PropertyValueEncoder.GetEncodedPropertyValue(_street, true), ";"));
            sb.Append(string.Concat(PropertyValueEncoder.GetEncodedPropertyValue(_locality, true), ";"));
            sb.Append(string.Concat(PropertyValueEncoder.GetEncodedPropertyValue(_region, true), ";"));
            sb.Append(string.Concat(PropertyValueEncoder.GetEncodedPropertyValue(_postalCode, true), ";"));
            sb.Append(string.Concat(PropertyValueEncoder.GetEncodedPropertyValue(_country, true), "\r\n"));
            
            return sb.ToString();
        }
    }
}