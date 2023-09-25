using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureWell.Entity
{
    public class Specialization
    {
        [JsonProperty("specializationCode")]
        public string SpecializationCode { get; set; }
        [JsonProperty("specializationName")]
        public string SpecializationName { get; set; }

        public Specialization()
        {
        }

        public Specialization(string specializationCode, string specializationName)
        {
            SpecializationCode = specializationCode;
            SpecializationName = specializationName;
        }
    }
}
