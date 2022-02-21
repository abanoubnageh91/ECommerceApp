using System;

namespace ECommerceApp.API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal PayTotal { get; set; }
        public int AddressId { get; set; }

        public Address Address { get; set; }
    }
}