using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePassword.Data
{
    public class WebsitePassword
    {
        public class UsernameEmptyException : Exception
        {
            public UsernameEmptyException():base("Kullanıcı adı boş geçilemez.")
            {
                
            }
        }

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Website { get; set; }
        public string WebsiteUrl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CopyCount { get; private set; }
        public ICollection<WebsitePasswordHistory> PasswordHistories { get; set; }

        public void IncreaseCopyCount()
        {
            CopyCount++;
        }

        public void ChangeUsername(string newUsername)
        {
            if (string.IsNullOrEmpty(newUsername))
            {
                throw new UsernameEmptyException();
            }
            else
            {
                UserName = newUsername.Trim();
            }
        }
    }
}
