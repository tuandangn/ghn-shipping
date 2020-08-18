using System;

namespace GhnShipping.Models.Directory
{
    [Serializable]
    public sealed class DistrictModel
    {
        public int Id { get; set; }

        public int ProvinceId { get; set; }

        public string Name { get; set; }
    }
}
