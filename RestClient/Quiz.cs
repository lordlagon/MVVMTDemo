using System;
using System.Collections.Generic;
using System.Text;

namespace RestClient
{
    public class Quiz
    {
        public int Id_empresa { get; set; }
        public int Id_pergunta { get; set; }
        public Question Pergunta { get; set; }
        public int Situacao { get; set; }
        public string Tipo { get; set; }
    }
      
}
public class Question
{
    public string Query { get; set; }
    public string Tipo { get; set; }
}

