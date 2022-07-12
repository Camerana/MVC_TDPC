using System;

namespace MVC_TDPC13.DB.Entities
{
    public class Person
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public decimal? Stipendio { get; set; }
    }
}
