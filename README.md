# Overview
We wanted a standard reusable way to implement [vCards](http://en.wikipedia.org/wiki/VCard) across our Sitecore implementations.  To achieve this, we created a reusable API.  This vCard implementation supports the vCard 3.0 standard.

The API consists of a vCard object with properties that represent the data in the vCard file.  Calling .ToString() on the object takes all of the data within the properties and returns a string that represents the vCard file in the proper format.  The fields from the Sitecore item that represents a person can be programmatically mapped to the properties on the vCard object.  An ORM/Mapper can be used to make the mapping easier.   The resulting string can then be returned in a way that is compatible with the implementation.  A Sitecore Web Form implementation may return the data differently than an MVC implementation.

We hope this implementation saves time when implementing vCards.

> Coming Soon: Please see the related [Blog Post](http://www.onenorth.com/blog/post/sitecore-vcards)

# Usage
Here is a Sitecore MVC example of how to use OneNorth.VCards.  This example assumes that a person object is being used and Glass Mapper is used to map the data.

    public class PersonController : SitecoreController
    {
	    ISitecoreContext _context;

		public PersonController() : this (new SitecoreContext())
		{
		}

		public PersonController(ISitecoreContext context)
		{
			_context = context;
		}
		
		[HttpGet]
	    public HttpResponseMessage GetVCard()
	    {
	        var person = _context.GetCurrentItem<Person>();
	        var vCard = GetVCard(person);
	
	        var response = new HttpResponseMessage(HttpStatusCode.OK)
	        {
	            Content = new StringContent(vCard.ToString(), Encoding.UTF8, "text/vcard")
	        };
	        response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
	        {
	            FileName = person.Name + ".vcf"
	        };
	        return response;
	    }
	    
		private VCard GetVCard(Person person)
	    {
	        var vcard = new VCard
	        {
	            Organization = person.Organization,
	            FirstName = person.FirstName,
	            MiddleName = person.MiddleName,
	            LastName = person.LastName,
	            Title = person.Title
	        };
	
	        vcard.EmailAddresses.Add(person.BusinessEmail);
	
	        if (!string.IsNullOrEmpty(person.BusinessPhone))
	        {
	            var phone = new PhoneNumber { PhoneNumberType = PhoneNumberTypes.WORK, Number = person.BusinessPhone };
	            vcard.PhoneNumbers.Add(phone);
	        }
	
	        if (!string.IsNullOrEmpty(person.BusinessFax))
	        {
	            var fax = new PhoneNumber { PhoneNumberType = PhoneNumberTypes.FAX, Number = person.BusinessFax };
	            vcard.PhoneNumbers.Add(fax);
	        }
	        
	        if (!string.IsNullOrEmpty(person.MobilePhone))
	        {
	            var cell = new PhoneNumber { PhoneNumberType = PhoneNumberTypes.CELL, Number = lawyer.MobilePhone };
	            vcard.PhoneNumbers.Add(cell);
	        }
	  
	        var deliveryAddress = new DeliveryAddress
	        {
	            DeliveryAddressType = AddressTypes.WORK,
	            Street = person.Street.Replace("\r\n", " ").Replace("\r", " ").Replace("\n", " "),
	            Locality = person.City
	        };
	
	        if (person.State != null)
	            deliveryAddress.Region = person.State.Name;
	
	        if (person.Country != null)
	            deliveryAddress.Country = person.Country.Name;
	
	        deliveryAddress.PostalCode = person.PostalCode;
	
	        vcard.Addresses.Add(deliveryAddress);
	        
	        return vcard;
	    }
	}
        
    
# License

The associated code is released under the terms of the [MIT License](http://onenorth.mit-license.org/)