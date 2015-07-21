using System;
using System.Collections.Generic;

namespace FreshMvvmCustomNavSample
{
    public interface IDatabaseService
    {
        List<Contact> GetContacts ();

        void UpdateContact (Contact contact);

        List<Quote> GetQuotes ();

        void UpdateQuote (Quote quote);
    }
}

