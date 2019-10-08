using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        [Key]
        //[JsonProperty("userid")]
        public string UserId { get; set; }

       // [JsonProperty("email")]
        public string EmailId { get; set; }

        //[JsonProperty("password")]
        public string Password { get; set; }

        //[JsonProperty("usertype")]
        public string UserType { get; set; }

        //[JsonProperty("newpassword")]
        public string NewPassword { get; set; }

    }
}
