using empregare.Models;
using empregare.Repository.Interfaces;
using empregare.Repository.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace empregare.Repository.Services
{
    public class CandidatoService : ICandidatoService
    {
        private readonly ICandidato _candidato;

        public CandidatoService(ICandidato candidato)
        {
            _candidato = candidato;
        }

        public async Task<Candidato> GetByEmail(string email)
        {
            return await _candidato.GetByEmail(email);
        }

        public async Task<Candidato> Insert(Candidato candidato)
        {
            await _candidato.Insert(candidato);
            return candidato;
        }

        public async Task<bool> Login(Candidato candidato)
        {
            try
            {
                Candidato c = await GetByEmail(candidato.Email);
                if (c != null)
                {
                    if (c.Senha.Equals(candidato.Senha))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
