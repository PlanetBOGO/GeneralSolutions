using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace GeneralSolutions
{
    public class CategoryMetadata
    {
        [Display(Name = "Category")]
        public string Name { get; set; }

        [XmlIgnoreAttribute]
        public virtual ICollection<Item> Items { get; set; }
    }
}
