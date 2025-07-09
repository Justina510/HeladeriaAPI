using AutoMapper;
using HeladeriaAPI.Config;
using HeladeriaAPI.Models.Helado;
using HeladeriaAPI.Models.Helado.Dto;
using HeladeriaAPI.Utils;
using System.Net;

namespace HeladeriaAPI.Services
{
    public class HeladoServices
    {
        private readonly IMapper _mapper;
        public HeladoServices(IMapper mapper) {
            _mapper = mapper;
        }

        public static List<Helado> Helados = new List<Helado>()
        {
            new() { Id = 1, Nombre = "Sambayon", Descripcion = "Helado de sambayon", Precio = 5.00, Ingredientes = new() { "Leche", "Azucar", "Alcohol" } },
            new() { Id = 2, Nombre = "Granizado", Descripcion = "Crema con chispas de chocolate", Precio = 6.50, Ingredientes = new() { "Leche", "Azucar", "Chocolate", "Crema" } },
            new() { Id = 3, Nombre = "Frutilla Chantilly", Descripcion = "Dulce, suave y frutal", Precio = 7.77, Ingredientes = new() { "Leche", "Azucar", "Frutillas", "Crema Chantilly" } },
        };

        public Helado GetOneByIdOrException(int id)
        {
            var helado = Helados.FirstOrDefault(hel => hel.Id == id);

            if (helado == null)
            {
                throw new HttpError($"No se eoncontro el helado con ID = {id}", HttpStatusCode.NotFound);
            }

            return helado;
        }

        public List<Helado> GetAll()
        {
            return Helados;
        }

        public Helado GetOneById(int id)
        {
            return GetOneByIdOrException(id);
        }

        public Helado CreateOne(CreateHeladoDTO helado) {
            int lastId = Helados.Count;

            var h = _mapper.Map<Helado>(helado);

            h.Id = lastId + 1;

            Helados.Add(h);
            return h;
        }

        public Helado UpdateOneById(int id, UpdateHeladoDTO helado)
        {
            var heladoToUpdate = GetOneByIdOrException(id);
            // Actualizar los valores del helado
            var heladoUpdated = _mapper.Map(helado, heladoToUpdate);

            // Actualizar el helado en la lista a partir del índice
            Helados[Helados.IndexOf(heladoToUpdate)] = heladoUpdated;

            return heladoToUpdate;
        }

        public void DeleteOneById(int id)
        {
            var helado = GetOneByIdOrException(id);
            Helados.Remove(helado);
        }
          
    }
}
