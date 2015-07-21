using System;
using PropertyChanged;

namespace FreshMvvmCustomNavSample
{
    [ImplementPropertyChanged]
    public class Quote
    {
        public Quote ()
        {
        }
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public string Total { get; set; }
    }
}

