using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UploadWorkRequestDTO
    {
        public string Title {  get; set; } = null!;
        public string OwnerName { get; set; } = null!;
        public string AdditionalOwner { get; set; } = null!;
    }
}
