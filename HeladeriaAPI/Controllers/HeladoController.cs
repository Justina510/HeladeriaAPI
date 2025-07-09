using HeladeriaAPI.Models.Helado;
using HeladeriaAPI.Models.Helado.Dto;
using HeladeriaAPI.Services;
using HeladeriaAPI.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HeladeriaAPI.Controllers
{
    [Route("api/helados")]
    [ApiController]
    public class HeladoController : ControllerBase
    {
        private readonly HeladoServices _heladoServices;

        public HeladoController(HeladoServices heladoServices)
        {
            _heladoServices = heladoServices;
        }

        [HttpGet]
        public List<Helado> GetHelados()
        {
            return _heladoServices.GetAll();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(HttpMessage))]
        public ActionResult<Helado> GetHelado(int id)
        {
            try
            {
                return _heladoServices.GetOneById(id);
            }
            catch (HttpError ex)
            {
                return StatusCode((int)ex.StatusCode, new HttpMessage(ex.Message));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new HttpMessage("Algo salio mal"));
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Helado))]
        public ActionResult Create([FromBody] CreateHeladoDTO helado)
        {
            var heladoCreated = _heladoServices.CreateOne(helado);
            return Created("api/helados", heladoCreated);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Helado))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(HttpMessage))]
        public ActionResult<Helado> Update(int id, [FromBody] UpdateHeladoDTO helado)
        {
            try
            {
                return _heladoServices.UpdateOneById(id, helado);
            }
            catch (HttpError ex)
            {
                return StatusCode((int)ex.StatusCode, new HttpMessage(ex.Message));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new HttpMessage($"Algo salio mal actualizando el helado con ID = {id}"));
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(HttpMessage))]
        public ActionResult Delete(int id)
        {
            try
            {
                _heladoServices.DeleteOneById(id);
                return Ok(new HttpMessage($"Helado con ID = {id} eliminado correctamente."));
            }
            catch (HttpError ex)
            {
                return StatusCode((int)ex.StatusCode, new HttpMessage(ex.Message));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new HttpMessage($"Algo salio mal eliminando el helado con ID = {id}"));
            }
        }
    }
}
