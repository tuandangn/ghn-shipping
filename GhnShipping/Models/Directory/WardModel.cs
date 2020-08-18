using System;

namespace GhnShipping.Models.Directory
{
    [Serializable]
    public sealed class WardModel
    {
        public string Id { get; set; }

        public int DistrictId { get; set; }

        public string Name { get; set; }
    }
}
