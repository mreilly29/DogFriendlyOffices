using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DogOffices.Models
{
    public class Company
    {
        public int CompanyId { get; set; }

        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        [DisplayName("Website")]
        public string CompanyWebsiteUrl { get; set; }

        [DisplayName("About the Company")]
        public string CompanyDescription { get; set; }

        [DisplayName("Address")]
        public string CompanyAddress { get; set; }

        [DisplayName("City")]
        public string CompanyCity { get; set; }

        [DisplayName("State")]
        public string CompanyState { get; set; }

        [DisplayName("ZIP Code")]
        public int CompanyZipCode { get; set; }

        [DisplayName("Dogs")]
        public List<Dog> CompanyDogs { get; set; }
        public int CompanyDogId { get; set; }
    }
}
