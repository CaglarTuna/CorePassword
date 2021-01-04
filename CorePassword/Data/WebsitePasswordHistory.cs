using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePassword.Data
{
    public class WebsitePasswordHistory
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime ExpiredDate { get; set; }
        public string Password{ get; set; }
        public string WebsitePasswordId{ get; set; }

        public WebsitePassword WebsitePassword { get; set; }
    }
}
