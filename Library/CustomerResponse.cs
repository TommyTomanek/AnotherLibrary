﻿using Library.Models;

namespace Library
{
    public class CustomerResponse
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
