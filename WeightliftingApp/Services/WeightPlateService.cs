using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using WeightliftingApp.Web.Models;

namespace WeightliftingApp.Services
{
    public class WeightPlateService
    {
        public WeightPlateService(IConfiguration configuration, ILogger<WeightPlateService> logger)
        {
            this._logger= logger;
            barWeight = Convert.ToInt32(configuration["BarWeight"]);
        }
         
        private readonly decimal[] plateSizes = { 45m, 25m, 10m, 5m, 2.5m };
        private readonly WeightSettings _weightSettings;
        private readonly ILogger _logger;
        private int barWeight;
        public Dictionary<decimal, int> CalculatePlates(int targetWeight)
        {
            _logger.LogInformation("Target weight requested "+ targetWeight);
            try
            {
                decimal remainingWeight = (targetWeight - barWeight) / 2m;
                var plates = new Dictionary<decimal, int>();

                // Initialize all plate sizes with a count of 0
                foreach (decimal plate in plateSizes)
                {
                    plates[plate] = 0;
                }
                foreach (decimal plate in plateSizes)
                {
                    int count = (int)(remainingWeight / plate);
                    if (count > 0)
                    {
                        plates[plate] = count;
                        remainingWeight -= count * plate;
                    }
                }
                return plates;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw ex;
            }
        }

    }
}
