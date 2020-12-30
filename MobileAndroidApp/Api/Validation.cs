using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Validation
{
    public struct ValidationResults
    {
        public bool isValid;
        public string message;
    }

    class Hasher
    {
        public static string Hash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
            {
                byte[] buffer = algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));

                StringBuilder sb = new StringBuilder();
                foreach (byte b in buffer)
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }

    class Validator
    {
        public static ValidationResults ValidateUsername(string username)
        {
            string input = username;
            int minChar = 5;
            int maxChar = 20;
            string hasOnlyWordChars = @"^(\w+)$";
            string hasGoodAmountOfChars = $".{{{minChar},{maxChar}}}";

            Match matchChars = Regex.Match(input, hasOnlyWordChars);
            Match matchAmount = Regex.Match(input, hasGoodAmountOfChars);

            if (!matchChars.Success)
            {
                return new ValidationResults
                {
                    isValid = false,
                    message = "Username must contain only letters, numbers, or underscores"
                };
            }
            if (!matchAmount.Success)
            {
                return new ValidationResults
                {
                    isValid = false,
                    message = $"Username must contain between {minChar} and {maxChar} characters"
                };
            }
            return new ValidationResults
            {
                isValid = true,
                message = "Nickname is great!"
            };
        }

        public static ValidationResults ValidatePassword(string username)
        {
            string input = username;
            int minChar = 8;
            int maxChar = 32;
            string hasNumber = @"[0-9]+";
            string hasUpperChar = @"[A-Z]+";
            string hasGoodAmountOfChars = $".{{{minChar},{maxChar}}}";

            Match matchUpper = Regex.Match(input, hasUpperChar);
            Match matchNumber = Regex.Match(input, hasNumber);
            Match matchAmount = Regex.Match(input, hasGoodAmountOfChars);

            if (!matchUpper.Success || !matchNumber.Success || !matchAmount.Success)
            {
                return new ValidationResults
                {
                    isValid = false,
                    message = $"Password must contain uppercase letters, numbers, and {minChar}-{maxChar} characters"
                };
            }

            return new ValidationResults
            {
                isValid = true,
                message = "Password is great!"
            };

            //if (!matchUpper.Success)
            //{
            //    return new ValidationResults
            //    {
            //        isValid = false,
            //        message = "Password must contain uppercase letters"
            //    };
            //}
            //if (!matchNumber.Success)
            //{
            //    return new ValidationResults
            //    {
            //        isValid = false,
            //        message = "Password must contain numbers"
            //    };
            //}
            //if (!matchAmount.Success)
            //{
            //    return new ValidationResults
            //    {
            //        isValid = false,
            //        message = $"Password must contain between {minChar} and {maxChar} characters"
            //    };
            //}
        }

        public static ValidationResults ValidateEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return new ValidationResults
                {
                    isValid = addr.Address == email,
                    message = (addr.Address == email) ? "Email is great!" : "Email does not exist"
                };
            }
            catch
            {
                return new ValidationResults
                {
                    isValid = false,
                    message = "Invalid email input"
                };
            }
        }
    }
}
