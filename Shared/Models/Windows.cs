using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorExamApps.Shared.Models
{
    public partial class Windows
    {
        public Windows()
        {
            Elements = new HashSet<Elements>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public int? OrderId { get; set; }

        public virtual Orders Order { get; set; }
        public virtual ICollection<Elements> Elements { get; set; }
    }
}
