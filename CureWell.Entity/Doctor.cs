using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureWell.Entity
{
    public class Doctor
    {
        [JsonProperty("doctorId")]
        public int DoctorId { get; set; }

        [JsonProperty("doctorName")]
        public string DoctorName { get; set; }

        public Doctor()
        {

        }

        public Doctor(int doctorId, string doctorName)
        {
            DoctorId = doctorId;
            DoctorName = doctorName;
        }
    }
}