using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DogOffices.Models
{
    public class Dog
    {
        public int DogId { get; set; }
        [DisplayName("Name")]
        public string DogName { get; set; }

        [DisplayName("Breed")]
        public string DogBreed { get; set; }

        [DisplayName("Description")]
        public string DogDescription { get; set; }

        public int CompanyId { get; set; }
    }
}
