using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorExamApps.Shared.Models
{
    public partial class Orders
    {
        public Orders()
        {
            Windows = new HashSet<Windows>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }

        public virtual ICollection<Windows> Windows { get; set; }
    }
}
