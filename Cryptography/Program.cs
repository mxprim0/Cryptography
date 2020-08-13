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
    class Program
    {
        static void Main(string[] args)
        {
            string html = string.Empty;
            string url = @"https://api.codenation.dev/v1/challenge/dev-ps/generate-data?token=x";
            string token = string.Empty;
            string file = "answer.json";
            string path = @"C:\TEMP\";

            token = Console.ReadLine();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + token);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            StreamWriter streamWriter = File.AppendText(path + file);
            streamWriter.Write(html);
            streamWriter.Close();

            Console.WriteLine($"File copied to {path}");
            Console.ReadKey();

            Challenge challenge = JsonConvert.DeserializeObject<Challenge>(html);
            Console.WriteLine($"numero_casas: {challenge.numero_casas}, token: {challenge.token}, " +
                $"cifrado: {challenge.cifrado}, decifrado: {challenge.decifrado}, resumo_criptografico: {challenge.resumo_criptografico} ");

            string decripted = Logic.DecriptMessage(int.Parse(challenge.numero_casas), challenge.cifrado.ToLower());
            Console.WriteLine(decripted);
            challenge.decifrado = decripted;

            string hash = Logic.Hash(challenge.decifrado);
            Console.WriteLine(hash);
            challenge.resumo_criptografico = hash;

            html = JsonConvert.SerializeObject(challenge);
            File.WriteAllText(path + file + html);
            
            Console.ReadKey();
        }
    }
}
