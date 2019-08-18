using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyCsvParser.Mapping;

namespace AspnetCoreSPATemplate.Models
{
    public class CsvContactMapping : CsvMapping<Contact>
    {
        public CsvContactMapping() : base()
        {
            MapProperty(0, x => x.first_name);
            MapProperty(1, x => x.last_name);
            MapProperty(2, x => x.company_name);
            MapProperty(3, x => x.address);
            MapProperty(4, x => x.city);
            MapProperty(5, x => x.state);
            MapProperty(6, x => x.post);
            MapProperty(7, x => x.phone1);
            MapProperty(8, x => x.phone2);
            MapProperty(9, x => x.email);
            MapProperty(10, x => x.web);
        }
    }
}


