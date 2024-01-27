﻿using CaseStudy.Concentrix.Abstraction.Interface;
using CaseStudy.Concentrix.Abstraction.Model;
using Serilog;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Collections;

namespace CaseStudy.Concentrix.Application
{
    public class OrderService : IOrderService
    {
     
        private readonly ILogger _logger = Log.Logger.ForContext<OrderService>();
        private readonly IInMemoryCache _inMemoryCache;
        private static object _lock = new object();
        private static string path = @"E:\\CaseStudy\\CaseStudy.Concentrix.Infrastructure\\CaseStudy.Concentrix,Infrastrucure\\Data\\Order.txt";
        public OrderService(ILogger logger, IInMemoryCache inMemoryCache)
        {
           _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _inMemoryCache = inMemoryCache;

        }

        public async Task<int> PlaceOrderAsync(Order order)
        {
            List<Order> orderList = new List<Order>();
            var orderCollection = DeserializeToObject<Order>(path);
            if (orderCollection==null)
            {         
                orderList.Add(order);
            }
            else
            {
                orderList = orderCollection;
                orderList.Add(order);
            }
            SerializeToJSON(orderList, path);
            _inMemoryCache.RemoveData("order");
            return order.Id;
        }

        public async Task<List<Order>> GetOrders(int page, int pageSize)
        {
            var cacheData = _inMemoryCache.GetData<IEnumerable<Order>>("order");
            if (cacheData != null)
            {
                IList<Order> specific = GetPage(cacheData, page, pageSize);
                return (List<Order>)specific;
            }
            lock (_lock)
            {
                var expirationTime = DateTimeOffset.Now.AddMinutes(5.0);
                cacheData = (IEnumerable<Order>?)DeserializeToObject<Order>(path);
                _inMemoryCache.SetData<IEnumerable<Order>>("order", cacheData, expirationTime);
                }
             return (List<Order>)cacheData;
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            Order filteredData;
            var cacheData = _inMemoryCache.GetData<IEnumerable<Order>>("order");
            if (cacheData != null)
            {
                filteredData = cacheData.Where(x => x.Id == orderId).FirstOrDefault();
                return filteredData;
            }
            var orderCollection = DeserializeToObject<Order>(path);
            filteredData = orderCollection.Where(x => x.Id == orderId).FirstOrDefault();
            return filteredData;
 
        }


        private IList<Order> GetPage(IEnumerable<Order> list, int page, int pageSize)
        {
            return list.Skip(page * pageSize).Take(pageSize).ToList();
        }

        private static void SerializeToJSON<T>(List<T> anyobject, string jsonFilePath)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(anyobject);
            File.WriteAllText(jsonFilePath, json);
        }
        private static List<T> DeserializeToObject<T>(string filepath) where T : class
        {
            var serializer = new Newtonsoft.Json.JsonSerializer();
            List<T> collection = new();
            using (var streamReader = new StreamReader(path))
            using (var textReader = new JsonTextReader(streamReader))
            {
                collection = serializer.Deserialize<List<T>>(textReader);
            }
            return collection;
        }

    }
}
