﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBGE_API.Models {
    public class UnidadesFederativas {
        public int id { get; set; }
        public string nome { get; set; }
        public Microrregiao microrregiao { get; set; }
        public RegiaoImediata regiaoimediata { get; set; }
    }

    public class Microrregiao {
        public int id { get; set; }
        public string nome { get; set; }
        public Mesorregiao mesorregiao { get; set; }
    }

    public class Mesorregiao {
        public int id { get; set; }
        public string nome { get; set; }
        public UF UF { get; set; }
    }

    public class UF {
        public int id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
        public Regiao regiao { get; set; }
    }

    public class RegiaoImediata {
        public int id { get; set; }
        public string nome { get; set; }
        public RegiaoIntermediaria regiaointermediaria { get; set; }
    }

    public class RegiaoIntermediaria {
        public int id { get; set; }
        public string nome { get; set; }
        public string UF { get; set; }
    }
}
