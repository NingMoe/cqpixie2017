using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace cqpixie.Common.JSON
{
 
    public class JSONHelper
    {
  
        public static string ToJsonString(object obj)
        {
            if (obj == null)
                return string.Empty;
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        public static T ToObject<T>(string jsonString)
        {
            if (string.IsNullOrEmpty(jsonString))
                return default(T);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}