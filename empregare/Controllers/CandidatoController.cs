using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using empregare.Models;
using empregare.Repository.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace empregare.Controllers
{
    [Route("[controller]")]
    public class CandidatoController : Controller
    {
        private readonly ICandidatoService _candidato;

        public CandidatoController(ICandidatoService candidato)
        {
            _candidato = candidato;
        }

        [HttpGet]
        [Route("cadastro")]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [Route("cadastro")]
        public dynamic CadastroPost(Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                _candidato.Insert(candidato);
                return new { status = 200, message = string.Format("Usuário {0} cadastrado com sucesso!", candidato.Nome) };
            }
            else
            {
                return new { status = 400, message = "Erro no cadastro, tente novamente!" };
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginPost(Candidato candidato)
        {
            try
            {
                if (!await _candidato.Login(candidato))
                    return View("Logado");
                Candidato candidatoLogado = await _candidato.GetByEmail(candidato.Email);
                ViewData.Model = candidatoLogado;
                return View("Logado");
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
