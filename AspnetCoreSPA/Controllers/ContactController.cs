using AspNetCoreSpaTemplate.Core;
using AspNetCoreSpaTemplate.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace AspnetCoreSPATemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly IContactData contactData;

        public ContactController(IConfiguration config, IContactData contactData)
        {
            this.config = config;
            this.contactData = contactData;
        }

        // GET: api/Contact
        [HttpGet]
        public IEnumerable<Contact> GetContacts(string term, int pageNumber, int pageSize)
        {
            return contactData.GetContactsByName(term, pageNumber, pageSize);
        }

        // GET: api/Contact/5
        [HttpGet("{id}")]
        public IEnumerable<Contact> GetContact(int id)
        {
            return contactData.GetContactsById(id);
        }
    }
}
