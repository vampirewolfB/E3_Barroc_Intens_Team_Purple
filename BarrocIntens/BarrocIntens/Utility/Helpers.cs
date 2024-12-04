using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BarrocIntens.Utility
{
    internal class Helpers
    {
        // Regex validator for emails
        // This does not check if the email actually exists
        public static bool EmailChecker(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                // Examines the domain part and normalizes it
                string DomainMapper(Match match)
                {
                    IdnMapping idn = new IdnMapping();
                    string domainName = idn.GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + domainName;
                }

                email = Regex.Replace(email,
                                      @"(@)(.+)$",
                                      DomainMapper,
                                      RegexOptions.None,
                                      TimeSpan.FromMilliseconds(200));

            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                // Validates and returns true if matches otherwise false.
                return Regex.IsMatch(email,
                                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                                    RegexOptions.IgnoreCase,
                                    TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        // Create a random password
        public static string PasswordGen(int lenght, int numberOfNonAlphanumericCharacters)
        {
            // Character list
            char[] punctuations = "!@#$%^&*()_-+=[{]};:>|./?".ToCharArray();

            // Validation for lenght and numberOfNonAlphanumericCharacters
            if (lenght < 1 || lenght > 128)
            {
                throw new ArgumentException(nameof(lenght));
            }

            if (numberOfNonAlphanumericCharacters > lenght || numberOfNonAlphanumericCharacters < 0)
            {
                throw new ArgumentException(nameof(numberOfNonAlphanumericCharacters));
            }

            //  Create new random values.
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] byteBuffer = new byte[lenght];
                rng.GetBytes(byteBuffer);

                int count = 0;
                char[] characterBuffer = new char[lenght];

                for (int iter = 0; iter < lenght; iter++)
                {
                    int i = byteBuffer[iter] % 87;

                    if (i < 10)
                    {
                        characterBuffer[iter] = (char)('0' + i);
                    }
                    else if (i < 36)
                    {
                        characterBuffer[iter] = (char)('A' + i - 10);
                    }
                    else if (i < 62)
                    {
                        characterBuffer[iter] = (char)('a' + i - 36);
                    }
                    else
                    {
                        characterBuffer[iter] = punctuations[i - 62];
                        count++;
                    }
                }

                if (count >= numberOfNonAlphanumericCharacters)
                {
                    return new string(characterBuffer);
                }

                int j;
                Random random = new Random();

                for (j = 0; j < numberOfNonAlphanumericCharacters - count; j++)
                {
                    int k;
                    do
                    {
                        k = random.Next(0, lenght);
                    }
                    while (!char.IsLetterOrDigit(characterBuffer[k]));

                    characterBuffer[k] = punctuations[random.Next(0, punctuations.Length)];
                }

                return new string(characterBuffer);
            }
        }
    }
}
