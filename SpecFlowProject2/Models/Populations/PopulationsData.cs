using Newtonsoft.Json;


namespace SpecFlowProject2.Models.Populations
{
    internal class PopulationsData
    {
        public CountryPopulation[] data;
        public DataSource[] source;

    }

    internal class CountryPopulation
    {
        [JsonProperty("ID Nation")]
        public string nationId { get; set; }

        [JsonProperty("Nation")]
        public string nation { get; set; }

        [JsonProperty("ID Year")]
        public int idYear { get; set; }

        [JsonProperty("Year")]
        public string year { get; set; }

        [JsonProperty("Population")]
        public long population { get; set; }

        [JsonProperty("Slug Nation")]
        public string slugNation { get; set; }

    }

    internal class DataSource
    {
        public string[] measures { get; set; }
        public Annotations annotations { get; set; }
        public string name { get; set; }
        public string[] substitutions { get; set; }
      
    }



    internal class Annotations
    {   
        public string source_name { get; set; }
        public string source_description { get; set; }
        public string dataset_name { get; set; }
        public string dataset_link { get; set; }
        public string table_id { get; set; }
        public string topic { get; set; }
   
    }
}
