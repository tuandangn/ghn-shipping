using System;

namespace GhnShipping.Domain.Directory
{
    [Serializable]
    public class District
    {
        public int Id { get; set; }

        public int ProvinceId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        //*TODO*
        public int Type { get; set; }

        //*TODO*
        public int SupportType { get; set; }
    }
}
