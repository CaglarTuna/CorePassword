using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePassword.Services
{
    public interface IPasswordGenerator
    {
        string GeneratePassword(int passwordLength, int minUpperCaseLength, int minLowerCaseLength,
            int minSpecialCharLength, int minNumericLength);
    }
}
