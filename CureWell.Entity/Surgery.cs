using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureWell.Entity
{
    public class Surgery
    {
        [JsonProperty("doctorId")]
        public int? DoctorId { get; set; }
        [JsonProperty("endTime")]
        public decimal EndTime { get; set; }
        [JsonProperty("startTime")]
        public decimal StartTime { get; set; }
        [JsonProperty("surgeryCategory")]
        public string SurgeryCategory { get; set; }
        [JsonProperty("surgeryDate")]
        public DateTime SurgeryDate { get; set; }
        [JsonProperty("surgeryId")]
        public int SurgeryId { get; set; }

        public Surgery()
        {

        }

        public Surgery(int? doctorId, decimal endTime, decimal startTime, string surgeryCategory, DateTime surgeryDate, int surgeryId)
        {
            DoctorId = doctorId;
            EndTime = endTime;
            StartTime = startTime;
            SurgeryCategory = surgeryCategory;
            SurgeryDate = surgeryDate;
            SurgeryId = surgeryId;
        }
    }
}
