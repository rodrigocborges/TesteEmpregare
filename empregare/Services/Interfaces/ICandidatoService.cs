using empregare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace empregare.Repository.Services.Interfaces
{
    public interface ICandidatoService
    {
        Task<dynamic> Insert(Candidato candidato);

        dynamic GetByEmail(string email);
        bool Login(Candidato candidato);
    }
}
