using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureWell.Entity
{
    public class User
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        public User()
        {
        }

        public User(int userId, string email, string password)
        {
            UserId = userId;
            Email = email;
            Password = password;
        }

        public User(string email,string password)
        {
            Email = email;
            Password = password;
        }
    }
}
