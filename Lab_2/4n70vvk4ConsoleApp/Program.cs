using System;
using System.IO;
using System.Collections.Generic;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebSportsShop
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Fio { get; set; }
        public string PhoneNumber { get; set; }
        public string Comment { get; set; }

        public Client() { }
        public Client(int clientid, string fio, string phonenumber, string comment)
        {
            ClientId = clientid;
            Fio = fio;
            PhoneNumber = phonenumber;
            Comment = comment;
        }
    }

    public class Ordered
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public float Cost { get; set; }
        public int Amount { get; set; }
        public float Discount { get; set; }

        public Ordered() { }
        public Ordered(int orderid, int productid, float cost, int amount, float discount)
        {
            OrderID = orderid;
            ProductID = productid;
            Cost = cost;
            Amount = amount;
            Discount = discount;
        }
    }
    public class JsonHandler<T> where T : class
    {
        private string NameFile;
        JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

        public JsonHandler() { }

        public JsonHandler(string NameFile)
        {
            this.NameFile = NameFile;
        }

        public void SetFileName(string NameFile)
        {
            this.NameFile = NameFile;
        }

        public void Write(List<T> list)
        {
            string jsonString = JsonSerializer.Serialize(list, options);

            if (new FileInfo(NameFile).Length == 0)
            {
                File.WriteAllText(NameFile, jsonString);
            }
            else
            {
                Console.WriteLine("Указанный путь к файлу не пустой");
            }
        }

        public void Delete()
        {
            File.WriteAllText(NameFile, string.Empty);
        }

        public void Rewrite(List<T> list)
        {
            string jsonString = JsonSerializer.Serialize(list, options);

            File.WriteAllText(NameFile, jsonString);
        }

        public void Read(ref List<T> list)
        {
            if (File.Exists(NameFile))
            {
                if (new FileInfo(NameFile).Length != 0)
                {
                    string jsonString = File.ReadAllText(NameFile);
                    list = JsonSerializer.Deserialize<List<T>>(jsonString);
                }
                else
                {
                    Console.WriteLine("Указанный путь к файлу не пустой");
                }
            }
        }
        public void OutputJsonContents()
        {
            string jsonString = File.ReadAllText(NameFile);

            Console.WriteLine(jsonString);
        }

        public void OutputSerializedList(List<T> list)
        {
            Console.WriteLine(JsonSerializer.Serialize(list, options));
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            List<Client> partsList = new List<Client>();

            JsonHandler<Client> partsHandler = new JsonHandler<Client>("PartsFile.json");

            partsList.Add(new Client(2, "Vladimir Zhiltsov", "89205651337", "Good product", new Ordered(10, 2, "1500", 1, "75")));
            partsList.Add(new Client(1 "Anton Arabidze", "89105777801", "Actually high quality", new Ordered(7, 1, "5390", 1, "269,5")));
            partsList.Add(new Client(3, "Sergey Nelidkin", "89211488228", "Not bad at all", new Ordered(3, 3, "1272", 6, "63,6")));


            partsHandler.Rewrite(partsList);
            partsHandler.OutputJsonContents();
        }
    }
}
