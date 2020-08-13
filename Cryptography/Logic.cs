using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using Newtonsoft.Json;

namespace Cryptography
{
    public static class Logic
    {
        public static string DecriptMessage(int keyNumber, string message)
        {
            string decriptedMessage = null;
            string letters = "abcdefghijklmnopqrstuvwxyz";

            letters.ToCharArray();
            message.ToCharArray();

            foreach (char c in message)
            {
                if (letters.Contains(c))
                {
                    int lettersIndex = letters.IndexOf(c);
                    if (lettersIndex - keyNumber < 0)
                        lettersIndex = (lettersIndex - keyNumber) + 26;
                    else
                        lettersIndex -= keyNumber;

                    decriptedMessage += letters.Substring(lettersIndex, 1);
                }
                else
                {
                    decriptedMessage += c;
                }
            }

            return decriptedMessage;
        }

        public static string Hash(string input)
        {
            byte[] hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Concat(hash.Select(b => b.ToString("x2")));
        }
    }
}
