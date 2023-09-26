using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureWell.Entity
{
    public class DoctorDetails
    {
        [JsonProperty("doctorId")]
        public int DoctorId { get; set; }

        [JsonProperty("doctorName")]
        public string DoctorName { get; set; }

        [JsonProperty("specializations")]
        public List<Specialization> Specializations;

        [JsonProperty("surgeries")]
        public List<Surgery> Surgeries;

        public DoctorDetails()
        {

        }

        public DoctorDetails(int doctorId, string doctorName, List<Specialization> specializations, List<Surgery> surgeries)
        {
            DoctorId = doctorId;
            DoctorName = doctorName;
            Specializations = specializations;
            Surgeries = surgeries;
        }
    }
}
