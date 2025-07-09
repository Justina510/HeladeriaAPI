using AutoMapper;
using HeladeriaAPI.Models.Envase;
using HeladeriaAPI.Models.Envase.Dto;
using HeladeriaAPI.Utils;
using System.Net;

namespace HeladeriaAPI.Services
{
    public class EnvaseServices
    {
        private readonly IMapper _mapper;

        public EnvaseServices(IMapper mapper)
        {
            _mapper = mapper;
        }

        public static List<Envase> Envases = new List<Envase>()
        {
            new() { Id = 1, Tipo = "Pote 1kg", Descripcion = "Pote telgopor hasta 4 sabores", Precio = 15000, Comestible = false },
            new() { Id = 2, Tipo = "Pote 1/2 kg", Descripcion = "Pote telgopor hasta 4 sabores", Precio = 10000, Comestible = false },
            new() { Id = 3, Tipo = "Cucurucho 2 bochas", Descripcion = "Cucurucho de pasta de 2 bochas", Precio = 2100, Comestible = true },
            new() { Id = 4, Tipo = "Pote 1/4 kg", Descripcion = "Pote telgopor hasta 2 sabores", Precio = 4500, Comestible = false },
        };

        public Envase GetOneByIdOrException(int id)
        {
            var envase = Envases.FirstOrDefault(e => e.Id == id);
            if (envase == null)
            {
                throw new HttpError($"No se encontro el envase con ID = {id}", HttpStatusCode.NotFound);
            }
            return envase;
        }

        public List<Envase> GetAll()
        {
            return Envases;
        }

        public Envase GetOneById(int id)
        {
            return GetOneByIdOrException(id);
        }

        public Envase CreateOne(CreateEnvaseDTO envaseDTO)
        {
            int lastId = Envases.Count;
            var envase = _mapper.Map<Envase>(envaseDTO);
            envase.Id = lastId + 1;
            Envases.Add(envase);
            return envase;
        }

        public Envase UpdateOneById(int id, UpdateEnvaseDTO envaseDTO)
        {
            var envaseToUpdate = GetOneByIdOrException(id);
            var envaseUpdated = _mapper.Map(envaseDTO, envaseToUpdate);

            Envases[Envases.IndexOf(envaseToUpdate)] = envaseUpdated;
            return envaseToUpdate;
        }

        public void DeleteOneById(int id)
        {
            var envase = GetOneByIdOrException(id);
            Envases.Remove(envase);
        }
    }
}
