using Microsoft.Extensions.Logging;
using Sensitivewords_Business.Entities;
using Sensitivewords_Repository.Data.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sensitivewords_Repository.Data.SeedData
{
    public class SensitiveWordSeedContext
    {
        public static async Task SeedAsync(SensitiveWordsContext storeContext, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!storeContext.Words.Any())
                {
                    var wordData = File.ReadAllText("../Sensitivewords_Repository/Data/SeedData/sql_sensitive_list.txt");

                    var words = JsonSerializer.Deserialize<List<string>>(wordData);
                   
                    foreach (var item in words)
                    {
                        storeContext.Words.Add(new Word(){Name = item});
                        
                    }

                    await storeContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<SensitiveWordsContext>();
                logger.LogError(ex.Message);
            }
        }
    }
}
