using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoKnockout.Models
{
    public class Author
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "biography")]
        public string Biography { get; set; }

        [JsonProperty(PropertyName = "books")]
        public virtual ICollection<Book> Books { get; set; }
    }
}