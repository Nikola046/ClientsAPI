﻿namespace ClientsAPI.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
