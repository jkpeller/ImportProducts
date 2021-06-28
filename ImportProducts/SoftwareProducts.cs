using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ImportProducts
{
    public class SoftwareProducts
    {
        [JsonProperty("products")]
        public Product[] Products { get; set; }
    }

    public class Product
    {
        [JsonProperty("categories")]
        public string[] Categories { get; set; }

        [JsonProperty("twitter", NullValueHandling = NullValueHandling.Ignore)]
        public string Twitter { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
