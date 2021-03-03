using empregare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace empregare.Repository.Services.Interfaces
{
    public interface ICandidatoService
    {
        Task<Candidato> Insert(Candidato candidato);

        Task<Candidato> GetByEmail(string email);
        Task<bool> Login(Candidato candidato);
    }
}
