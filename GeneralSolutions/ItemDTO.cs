using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSolutions
{
    [Serializable]
    public class ItemDTO
    {
        public ItemDTO()
        {
        }

        public ItemDTO(Item i)
            : this()
        {
            Id = i.Id;
            Number = i.Number;
            Color = i.Color;
            Weight = i.Weight;
            IsAvailable = i.IsAvailable;
            PurchaseDate = i.PurchaseDate;
            Guid = i.Guid;
            CategoryId = i.CategoryId;
            FileName = i.FileName;
            Price = i.Price;
            Model = i.Model;
        }

        public int Id { get; set; }
        public long Number { get; set; }
        public string Color { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
        public Nullable<System.DateTime> PurchaseDate { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.Guid> Guid { get; set; }
        public string FileName { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string Model { get; set; }

        public Item ToItem()
        {
            return new Item
            {
                Id = this.Id,
                Number = this.Number,
                Color = this.Color,
                Weight = this.Weight,
                IsAvailable = this.IsAvailable,
                PurchaseDate = this.PurchaseDate,
                Guid = this.Guid,
                CategoryId = this.CategoryId,
                FileName = this.FileName,
                Price = this.Price,
                Model = this.Model

            };
        }
    }
}

////////////////////////////////////////////////////////////////////////////////////////////////////
// ItemDTO is required because XML serialization does not suppport virtual properties of Item class.
// Implementation: Parameterless Constructor is required for XML serialization
