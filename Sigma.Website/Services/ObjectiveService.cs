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
    public class ObjectiveService
    {
        private ConnectionService _connection;

        public ObjectiveService()
        {
            _connection = new ConnectionService();
        }

        public async Task<Objective> GetObjectiveById(string ObjectiveId)
        {
            string result = await _connection.GetDataAsync("GetObjectiveById", HttpComposedParameters.Of("Id", ObjectiveId));
            Objective ObjectiveObj = JsonConvert.DeserializeObject<Objective>(result);
            return ObjectiveObj;
        }

        public async Task<IEnumerable<Objective>> GetAllObjectives()
        {
            string resultText = await _connection.GetDataAsync("GetAllObjectives");
            dynamic result = JObject.Parse(resultText);
            JArray companiesArray = (JArray)result.Objectives;

            return companiesArray.ToObject<IEnumerable<Objective>>();
        }

        public async Task<bool> CreateObjective(Objective Objective)
        {
            string ObjectiveSerialized = JsonConvert.SerializeObject(Objective);
            return true;
        }

        public async Task<bool> EditObjective(Objective Objective)
        {
            string ObjectiveSerialized = JsonConvert.SerializeObject(Objective);
            return true;
        }

        public async Task<bool> DeleteObjective(string ObjectiveId)
        {
            return true;
        }
    }
}