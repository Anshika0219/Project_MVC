using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextingGameMVC.Models
{
    public class GetModel
    {
        public string? UserName { get; set; }

        public string EmailId { get; set; } = null!;
        public string? MobileNo { get; set; }
    }
}
