using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreSpaTemplate.Core
{
    public class ContactPagination
    {
        public IEnumerable<Contact> ContactList { get; set; }
     
        public int TotalPages { get; set; }
    }
}
