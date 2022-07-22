using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_TDPC.Models
{
    public class Person
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
    }
}
