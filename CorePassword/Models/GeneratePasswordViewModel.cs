using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePassword.Models
{
    public class GeneratePasswordViewModel
    {
        public int PasswordLength { get; set; }
        public int MinNumericCharLength { get; set; }
        public int MinSpecialCharLength { get; set; }
        public int MinLowerCaseCharLength { get; set; }
        public int MinUpperCaseCharLength { get; set; }
    }
}
