using empregare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace empregare.Repository.Interfaces
{
    public interface ICandidato
    {
        Task<Candidato> Insert(Candidato candidato);

        Task<Candidato> GetByEmail(string email);
    }
}
