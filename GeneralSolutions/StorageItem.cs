using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSolutions.Storage
{
    [Serializable]
    public class Item
    {
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
    }
}
