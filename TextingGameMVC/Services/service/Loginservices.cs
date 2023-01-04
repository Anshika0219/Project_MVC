using RequestModel;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.service
{
    public class Loginservices : ILoginservices
    {
        public IList<login> loginservices { get; set; }
        public HttpClient httpClient { get; set; }
    }
}
