using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebT.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string nameEvent { get; set; }
        public string placeEvent { get; set; }

        [DataType(DataType.DateTime)]
        public DataType startDateEvent { get; set; }

        [DataType(DataType.DateTime)]
        public DataType endDateEvent { get; set; }

        public string descriptionEvent { get; set; }
    }
}
