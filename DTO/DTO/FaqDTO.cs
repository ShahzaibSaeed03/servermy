using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FaqDTO
    {
        public string Question { get; set; } = null!;
        public string Answer { get; set; } = null!;
        public string Category { get; set; } = null!;
    }
}
