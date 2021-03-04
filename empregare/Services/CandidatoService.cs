using empregare.Models;
using empregare.Repository.Services.Interfaces;
using JsonFlatFileDataStore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace empregare.Repository.Services
{
    public class CandidatoService : ICandidatoService
    {
        public DataStore dataStore;
        public CandidatoService()
        {
            dataStore = new DataStore("db.json");
        }

        public dynamic GetByEmail(string email)
        {
            var candidatos = dataStore.GetCollection("usuarios");
            ExpandoObject response = candidatos.AsQueryable().FirstOrDefault(x => x.email == email);
            if (response == null)
                return null;

            var data = response.ToList();
            Candidato candidato = new Candidato {
                Id = Convert.ToInt32(data[0].Value),
                Nome = data[1].Value.ToString(),
                Telefone = data[2].Value.ToString(),
                Email = data[3].Value.ToString(),
                Senha = data[4].Value.ToString()
            };
            return candidato;
        }

        public async Task<dynamic> Insert(Candidato candidato)
        {
            try
            {
                var candidatos = dataStore.GetCollection("usuarios");
                await candidatos.InsertOneAsync(candidato);
                return candidato;
            }
            catch(Exception ex)
            {
                return new { message = ex.Message };
            }
        }

        public bool Login(Candidato candidato)
        {
            try
            {
                Candidato c = GetByEmail(candidato.Email);
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
