using System;

namespace GhnShipping.Domain.Directory
{
    [Serializable]
    public class Province
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }
    }
}
