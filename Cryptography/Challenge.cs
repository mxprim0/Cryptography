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
    public class Challenge
    {
        public string numero_casas;
        public string token;
        public string cifrado;
        public string decifrado;
        public string resumo_criptografico;

        public Challenge()
        {
        }

        public Challenge(string numero_casas, string token, string cifrado, string decifrado, string resumo_criptografico)
        {
            this.numero_casas = numero_casas;
            this.token = token;
            this.cifrado = cifrado;
            this.decifrado = decifrado;
            this.resumo_criptografico = resumo_criptografico;
        }
    }
}
