using Newtonsoft.Json;
using SpecFlowProject2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject2.Models
{
    internal class Location
    {
        [JsonProperty("post code")]
        public string postCode { get; set; }

        public string country { get; set; }

        [JsonProperty("country abbreviation")]
        public string countryAbbreviation { get; set; }

        public List<Place> places { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Location location &&
                   postCode == location.postCode &&
                   country == location.country &&
                   countryAbbreviation == location.countryAbbreviation &&
                   places.SequenceEqual(location.places);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(postCode, country, countryAbbreviation, places);
        }

        public override string ToString()
        {
            return ReflectionUtils.ToStringExtension(this);
        }
    }

    internal class Place
    {

        [JsonProperty("place name")]
        public string placeName { get; set; }

        public string longitude { get; set; }

        public string state { get; set; }

        [JsonProperty("state abbreviation")]
        public string stateAbbreviation { get; set; }

        public string latitude { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Place place &&
                   placeName == place.placeName &&
                   longitude == place.longitude &&
                   state == place.state &&
                   stateAbbreviation == place.stateAbbreviation &&
                   latitude == place.latitude;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(placeName, longitude, state, stateAbbreviation, latitude);
        }

        public override string ToString()
        {
            return ReflectionUtils.ToStringExtension(this);
        }
    }
}
