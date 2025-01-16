using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Service.Services.Consumers
{
    public class FaceBookPointConfig
    {
        public string BaseAddress { get; set; }
        public string PixelId { get; set; }
        public string Access_Token { get; set; }
        public bool EnableCallback { get; set; }
    }
}
