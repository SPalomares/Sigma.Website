﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sigma.Website.Models.Entities;
using Sigma.Website.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Sigma.Website.Services
{
    public class ClientService
    {
        private ConnectionService _connection;

        public ClientService()
        {
            _connection = new ConnectionService();
        }

        public async Task<Client> GetClientById(string ClientId)
        {
            string jsonResult = await _connection.GetDataAsync("GetClientById", HttpComposedParameters.Of("ClientId", ClientId));
            dynamic result = JObject.Parse(jsonResult);
            JObject clientObj = (JObject)result.Clients;

            return clientObj.ToObject<Client>();
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            string jsonResult = await _connection.GetDataAsync("GetAllClients");
            dynamic result = JObject.Parse(jsonResult);
            JArray companiesArray = (JArray)result.Clients;

            return companiesArray.ToObject<IEnumerable<Client>>();
        }

        public async Task<bool> CreateClient(Client Client)
        {
            string ClientSerialized = JsonConvert.SerializeObject(Client);
            return true;
        }

        public async Task<bool> EditClient(Client Client)
        {
            string ClientSerialized = JsonConvert.SerializeObject(Client);
            return true;
        }

        public async Task<bool> DeleteClient(string ClientId)
        {
            return true;
        }
    }
}