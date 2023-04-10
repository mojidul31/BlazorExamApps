using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorExamApps.Shared.Models
{
    public partial class Elements
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public int? WindowId { get; set; }

        public virtual Windows Window { get; set; }
    }
}
