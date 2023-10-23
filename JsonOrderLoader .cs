using Air_Tek_Coding_Challenge.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air_Tek_Coding_Challenge
{
    public class JsonOrderLoader : IOrderLoader
    {
        public List<Order> LoadOrders()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "coding-assigment-orders.json";
            JObject ordersJson = JObject.Parse(File.ReadAllText(path));
            List<Order> orders = new List<Order>();

            foreach (var orderJson in ordersJson)
            {
                string orderId = orderJson.Key;
                string destination = (string)orderJson.Value["destination"];

                orders.Add(new Order { OrderId = orderId, DestinationCity = destination });
            }

            return orders;
        }
    }
}
