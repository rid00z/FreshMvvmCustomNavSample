using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreshMvvmCustomNavSample
{
    public interface IDatabaseService
    {
        List<Contact> GetContacts ();

        void UpdateContact (Contact contact);

        List<Quote> GetQuotes ();

        Task UpdateQuote (Quote quote);
    }
}

