using System;

namespace GhnShipping.Domain.Directory
{
    [Serializable]
    public class Ward
    {
        public int Id { get; set; }

        public int DistrictId { get; set; }

        public string Name { get; set; }
    }
}
