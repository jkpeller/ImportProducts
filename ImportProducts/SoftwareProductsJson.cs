using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace ImportProducts
{
    public class SoftwareProductJson
    {
        [JsonProperty("products")]
        public ProductJson[] Products { get; set; }
    }

    public class ProductJson
    {
        [JsonProperty("categories")]
        public string[] Categories { get; set; }

        [JsonProperty("twitter", NullValueHandling = NullValueHandling.Ignore)]
        public string Twitter { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
