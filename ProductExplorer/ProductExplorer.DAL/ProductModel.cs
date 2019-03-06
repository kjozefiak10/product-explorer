using System;
using System.Collections.Generic;
using System.Text;

namespace ProductExplorer.DAL
{
    public class ProductModel
    {
        public ProductModel(int id, string name, string description, DateTime addedDate, DateTime? modificationDate)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description;
            AddedDate = addedDate;
            ModificationDate = modificationDate;
        }

        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public DateTime AddedDate { get; }
        public DateTime? ModificationDate { get; }
    }
}
