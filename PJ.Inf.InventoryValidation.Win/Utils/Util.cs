using Newtonsoft.Json;
using PJ.Inf.InventoryValidation.Win.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ.Inf.InventoryValidation.Win.Utils
{
    internal class Util
    {
        static string JsonConfigPath = "config.json";

        public static Config LoadConfig()
        {
            try
            {
                string json = System.IO.File.ReadAllText(JsonConfigPath);
                return JsonConvert.DeserializeObject<Config>(json);
            }
            catch (Exception ex)
            {
                return new Config(); // Devuelve una configuración vacía para evitar errores
            }
        }
    }
}
