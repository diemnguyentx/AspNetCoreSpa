using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspnetCoreSPATemplate.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TinyCsvParser;

namespace AspnetCoreSPATemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        // GET: api/Contact
        [HttpGet]
        public List<Contact> Get()
        {
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
            CsvContactMapping csvMapper = new CsvContactMapping();
            CsvParser<Contact> csvParser = new CsvParser<Contact>(csvParserOptions, csvMapper);
            var result = csvParser
                         .ReadFromFile(@"SampleData.csv", Encoding.ASCII)
                         .ToList();
            List<Contact> contacts = new List<Contact>();
            foreach (var details in result)
            {
                contacts.Add(new Contact
                {
                    first_name = details.Result.first_name,
                    last_name = details.Result.last_name,
                    email = details.Result.email,
                    phone1 = details.Result.phone1,
                    address = details.Result.address,
                    city = details.Result.city,
                    company_name = details.Result.company_name,
                    phone2 = details.Result.phone2,
                    post = details.Result.post,
                    state = details.Result.state,
                    web = details.Result.web
                    
                });
            }
            return contacts;
        }

    }
}
