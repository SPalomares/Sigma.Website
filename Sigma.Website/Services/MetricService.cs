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
    public class MetricService
    {
        private ConnectionService _connection;

        public MetricService()
        {
            _connection = new ConnectionService();
        }

        public async Task<Metric> GetMetricById(string MetricId)
        {
            string jsonResult = await _connection.GetDataAsync("GetMetricById", HttpComposedParameters.Of("MetricId", MetricId));
            dynamic result = JObject.Parse(jsonResult);
            JObject metricObj = (JObject)result.Company;

            return metricObj.ToObject<Metric>();
        }

        public async Task<IEnumerable<Metric>> GetAllMetrics()
        {
            string jsonResult = await _connection.GetDataAsync("GetAllMetrics");
            dynamic result = JObject.Parse(jsonResult);
            JArray companiesArray = (JArray)result.Metrics;

            return companiesArray.ToObject<IEnumerable<Metric>>();
        }

        public async Task<bool> CreateMetric(Metric Metric)
        {
            string MetricSerialized = JsonConvert.SerializeObject(Metric);
            return true;
        }

        public async Task<bool> EditMetric(Metric Metric)
        {
            string MetricSerialized = JsonConvert.SerializeObject(Metric);
            return true;
        }

        public async Task<bool> DeleteMetric(string MetricId)
        {
            return true;
        }
    }
}