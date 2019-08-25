using AspNetCoreSpaTemplate.Core;
using System;
using System.Collections.Generic;

namespace AspNetCoreSpaTemplate.Data
{
    public interface IContactData
    {
        IEnumerable<Contact> GetAll();
        IEnumerable<Contact> GetContactsByName(string term, int pageNumber, int pageSize);
        IEnumerable<Contact> GetContactsById(int id);
        ContactPagination GetContactPagination(string term, int pageNumber, int pageSize);
    }
}
