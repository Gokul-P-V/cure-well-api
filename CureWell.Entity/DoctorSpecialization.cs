using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureWell.Entity
{
    public class DoctorSpecialization
    {
        [JsonProperty("doctorId")]
        public int DoctorId { get; set; }
        [JsonProperty("specializationCode")]
        public string SpecializationCode { get; set; }
        [JsonProperty("specializationDate")]
        public DateTime SpecializationDate { get; set; }

        public DoctorSpecialization()
        {

        }

        public DoctorSpecialization(int doctorId, string specializationCode, DateTime specializationDate)
        {
            DoctorId = doctorId;
            SpecializationCode = specializationCode;
            SpecializationDate = specializationDate;
        }
    }
}
