using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;

namespace IdentitySample.Mvc.Models
{
    public class Prescription
    {

        public Prescription()
        {
            Id = Guid.NewGuid().ToString();
            CreatedDate = DateTime.UtcNow;
        }

        public DateTime CreatedDate { get; set; }

        public string Id { get; set; }


        [Display(Name = "موضوع")]
        public string Title { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        public string MedicJson { get; set; }

        [NotMapped]
        public IEnumerable<string> MedicList
        {
            get
            {
                var result = JsonConvert.DeserializeObject<IEnumerable<string>>(MedicJson ?? string.Empty);
                return result;
            }
            set
            {
                var result = JsonConvert.SerializeObject(value);
                MedicJson = result;
            }
        }

        [Display(Name = "کدملی")]
        public string NationalCode { get; set; }


    }
}


public class Storage
{
    public static IEnumerable<string> MedicList = new[] { "A", "B", "C", "D", "B", "C", "D" };
}
