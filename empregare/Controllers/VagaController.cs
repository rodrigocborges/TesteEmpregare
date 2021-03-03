using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using empregare.Models;
using Microsoft.AspNetCore.Mvc;

namespace empregare.Controllers
{
    [Route("[controller]")]
    public class VagaController : Controller
    {
        private IList<Vaga> vagas = new List<Vaga> {
            new Vaga { Id = 1, Empresa = "Amazon BR", Titulo = "Desenvolvedor .NET Core", Descricao = "Desenvolvimento de web api.", Tipo = TipoVaga.CLT, Salario = 4000 },
            new Vaga { Id = 2, Empresa = "YouTube BR", Titulo = "Engenheiro de Software", Descricao = "Desenvolvimento de um novo player.", Tipo = TipoVaga.CLT, Salario = 10000 }

        };

        public dynamic Index()
        {
            IList<dynamic> _vagas = new List<dynamic>();
            foreach(Vaga vaga in vagas)
            {
                _vagas.Add(new {
                    Id = vaga.Id,
                    Empresa = vaga.Empresa,
                    Titulo = vaga.Titulo,
                    Descricao = vaga.Descricao,
                    Tipo = TipoVaga.CLT.ToString(),
                    Salario = vaga.Salario
                });
            }
            return _vagas;
        }
    }
}
