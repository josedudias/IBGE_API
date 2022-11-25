using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBGE_API.Models {
    public class Rootobject {
        public Estados[] Property1 { get; set; }
    }

    public class Estados {
        public int Id { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public Regiao Regiao { get; set; }
    }

    public class Regiao {
        public int Id { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
    }
}
