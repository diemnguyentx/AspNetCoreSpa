using AspNetCoreSpaTemplate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCsvParser;

namespace AspNetCoreSpaTemplate.Data
{
    public class ContactData : IContactData
    {
        readonly List<Contact> contacts;

        CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
        CsvContactMapping csvMapper = new CsvContactMapping();
        
        public ContactData()
        {
            CsvParser<Contact> csvParser = new CsvParser<Contact>(csvParserOptions, csvMapper);
            var result = csvParser
                         .ReadFromFile(@"SampleData.csv", Encoding.ASCII)
                         .ToList();
            contacts = new List<Contact>();
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
        }
        public IEnumerable<Contact> GetAll()
        {
            return from r in contacts
                   select r;
        }


        public IEnumerable<Contact> GetContactsByName(string term, int pageNumber, int pageSize)
        {
            var query = contacts.AsQueryable();

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(x => x.first_name.Contains(term) || x.last_name.Contains(term));
            }

            query = query.Skip((pageNumber -1) * pageSize);
            query = query.Take(pageSize);

            return  query.ToList();
        }

        public IEnumerable<Contact> GetContactsById(int id)
        {
            throw new System.NotImplementedException();
        }

        
        public ContactPagination GetContactPagination(string term, int pageNumber, int pageSize)
        {
            var query = contacts.AsQueryable();
            int TotalPages = (int)Math.Ceiling((decimal)query.Count() / pageSize);

            IEnumerable<Contact> contactList = GetContactsByName(term, pageNumber, pageSize);

            var result = new ContactPagination() { TotalPages = TotalPages, ContactList = contactList};

            return result;
        }
    }
}
