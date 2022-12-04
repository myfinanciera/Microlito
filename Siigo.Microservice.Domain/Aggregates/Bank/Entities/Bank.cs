using Google.Protobuf.WellKnownTypes;
using System.Collections.Generic;

namespace Siigo.Microservice.Domain.Aggregates.Bank.Entities
{
    public sealed class Bank
    {
        public Order Order { get; set; }
    }

    public class Order
    {
        public string Id { get; set; }

        public string idcustomer { get; set; }

        public int number { get; set; }
       
        public bool state { get; set; }

        public IList<string> product { get; set; }

        public string email { get; set; }
    }
}