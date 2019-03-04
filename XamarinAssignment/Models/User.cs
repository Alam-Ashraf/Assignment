using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace XamarinAssignment.Models
{
    public class User
    {
        public List<Contact> contacts { get; set; }
    }

    public class Phone
    {
        public string mobile { get; set; }
        public string home { get; set; }
        public string office { get; set; }
    }

    public class Contact
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string gender { get; set; }
        public Phone phone { get; set; }

        [JsonIgnore]
        public ImageSource image {get; set;} = ImageSource.FromFile("user.png");
    }

}
