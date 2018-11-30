using System;
using System.Collections.Generic;
using System.Text;

namespace AppFarmacia.Models
{
    
        public class People
        {
            public string Razao { get; set; } //nome *
            public string Cpf { get; set; } //cpf *
            public object Rg { get; set; }
            public int Situacao { get; set; }
            public string Obs { get; set; }
            public string Alldata { get; set; }
            public DateTime Dt_cadastro { get; set; }
            public object Fone { get; set; }
            public object Celular { get; set; }
            public object Whatsapp { get; set; }
            public string Email { get; set; }
            public object site { get; set; }
            public string Cep { get; set; }
            public string Endereco { get; set; }
            public object Nr { get; set; }
            public object Complemento { get; set; }
            public string Bairro { get; set; }
            public string Cidade { get; set; }
            public string Uf { get; set; }
            public object Lat { get; set; }
            public object Lng { get; set; }
            public string Tags { get; set; }
            public DateTime Sata_nascto { get; set; }
            public string Sexo { get; set; }
        }
    
}
