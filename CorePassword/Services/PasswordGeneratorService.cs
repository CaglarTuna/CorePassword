using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePassword.Services
{
    public class PasswordGeneratorService : IPasswordGenerator
    {
        private string[] normalChars =
        {
            "A", "a", "B", "b", "C", "c", "D", "d", "E", "e", "F", "f", "G", "g", "H", "h", "I", "i", "J", "j", "K",
            "k", "L", "l", "M", "m", "N", "n", "O", "o", "P", "p", "Q", "q", "R", "r", "S", "s", "T", "t", "U", "u",
            "W", "w", "X", "x", "Y", "y", "Z", "z", "0","1","2","3","4","5","6","7","8","9","?",".","_","!","-"
        };

        private string[] specialChars = {"?", ".", "_", "!", "-"};

        private char[] passwordCharArray = new char[0];

        private Random rng = new Random();

        public string GeneratePassword(int passwordLength, int minUpperCaseLength, int minLowerCaseLength, int minSpecialCharLength,
            int minNumericLength)
        {
            passwordCharArray = new char[0];

            if (minLowerCaseLength + minUpperCaseLength + minSpecialCharLength + minNumericLength != passwordLength)
            {
                return "";
            }
            else
            {
                for (int i = 0; i < passwordLength; i++)
                {
                    bool isUpperCase = false;
                    bool isLowerCase = false;
                    bool isNumeric = false;
                    bool isSpecialChar = false;

                    int randomNumber = rng.Next(0, normalChars.Length);

                    char selectedChar = char.Parse(normalChars[randomNumber]);

                    if (char.IsNumber(selectedChar))
                    {
                        isNumeric = true;
                    }
                    else if(char.IsUpper(selectedChar))
                    {
                        isUpperCase = true;
                    }
                    else if (char.IsLower(selectedChar))
                    {
                        isLowerCase = true;
                    }
                    else
                    {
                        isSpecialChar = true;
                    }

                    int lowerCaseCharTotal = 0;
                    int upperCaseCharTotal = 0;
                    int specialCharTotal = 0;
                    int numericTotal = 0;

                    for (int j = 0; j < passwordCharArray.Length; j++)
                    {
                        if (char.IsNumber(passwordCharArray[j]))
                        {
                            numericTotal++;
                        }
                        else if (char.IsUpper(passwordCharArray[j]))
                        {
                            upperCaseCharTotal++;
                        }
                        else if (char.IsLower(passwordCharArray[j]))
                        {
                            lowerCaseCharTotal++;
                        }
                        else if (specialChars.Contains(passwordCharArray[j].ToString()))
                        {
                            specialCharTotal++;
                        }
                    }

                    if (lowerCaseCharTotal < minLowerCaseLength && isLowerCase)
                    {
                        Array.Resize(ref passwordCharArray,passwordCharArray.Length + 1);
                        passwordCharArray[passwordCharArray.Length - 1] = Convert.ToChar(normalChars[randomNumber]);
                    }

                    else if (upperCaseCharTotal < minUpperCaseLength&& isUpperCase)
                    {
                        Array.Resize(ref passwordCharArray, passwordCharArray.Length + 1);
                        passwordCharArray[passwordCharArray.Length - 1] = Convert.ToChar(normalChars[randomNumber]);
                    }

                    else if (specialCharTotal < minSpecialCharLength && isSpecialChar)
                    {
                        Array.Resize(ref passwordCharArray, passwordCharArray.Length + 1);
                        passwordCharArray[passwordCharArray.Length - 1] = Convert.ToChar(normalChars[randomNumber]);
                    }

                    else if (numericTotal < minNumericLength && isNumeric)
                    {
                        Array.Resize(ref passwordCharArray, passwordCharArray.Length + 1);
                        passwordCharArray[passwordCharArray.Length - 1] = Convert.ToChar(normalChars[randomNumber]);
                    }
                    else
                    {
                        i--;
                        continue;
                    }
                }

                return new string(passwordCharArray);
            }
        }
    }
}
