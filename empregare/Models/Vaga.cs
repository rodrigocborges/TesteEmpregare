using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace empregare.Models
{
    public enum TipoVaga
    {
        CLT,
        PJ,
        Estagio
    }
    public class Vaga
    {
        public int Id { get; set; }
        public string Empresa { get; set; }
        public string Titulo { get; set; }
        public TipoVaga Tipo { get; set; }
        public string Descricao { get; set; }
        public decimal Salario { get; set; }
    }
}
