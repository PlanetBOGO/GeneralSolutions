//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GeneralSolutions
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        public int Id { get; set; }
        public long Number { get; set; }
        public string Color { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
        public Nullable<System.DateTime> PurchaseDate { get; set; }
        public Nullable<decimal> Price { get; set; }
        public byte[] Image { get; set; }
        public Nullable<System.Guid> Guid { get; set; }
        public string XML { get; set; }
        public byte[] Blob { get; set; }
        public string FileName { get; set; }
        public byte[] TimeStamp { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string Model { get; set; }
    
        public virtual Category Category { get; set; }
    }
}
