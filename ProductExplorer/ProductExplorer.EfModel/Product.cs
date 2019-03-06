using System;

namespace ProductExplorer.EfModel
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
