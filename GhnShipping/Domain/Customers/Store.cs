using System;

namespace GhnShipping.Domain.Customers
{
    [Serializable]
    public class Store
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public int WardId { get; set; }

        public int DistrictId { get; set; }

        public int ClientId { get; set; }

        public int BankAccountId { get; set; }

        public int Status { get; set; }
    }
}
