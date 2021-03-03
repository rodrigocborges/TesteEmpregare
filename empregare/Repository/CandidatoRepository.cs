using empregare.Models;
using empregare.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace empregare.Repository
{
    public class CandidatoRepository : ICandidato
    {
        private readonly AppDbContext _appDbContext;

        public CandidatoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Candidato> GetByEmail(string email)
        {
            return await _appDbContext.Candidatos.Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<Candidato> Insert(Candidato candidato)
        {
            await _appDbContext.Candidatos.AddAsync(candidato);
            await _appDbContext.SaveChangesAsync();
            return candidato;
        }
    }
}
