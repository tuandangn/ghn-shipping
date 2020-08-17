using System;

namespace GhnShipping.Domain.Services
{
    [Serializable]
    public class Service
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Type { get; set; }
    }
}
