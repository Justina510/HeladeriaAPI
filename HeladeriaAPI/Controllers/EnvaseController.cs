using HeladeriaAPI.Models.Envase;
using HeladeriaAPI.Models.Envase.Dto;
using HeladeriaAPI.Services;
using HeladeriaAPI.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeladeriaAPI.Controllers
{
    [Route("api/envases")]
    [ApiController]
    public class EnvaseController : ControllerBase
    {
        private readonly EnvaseServices _envaseServices;

        public EnvaseController(EnvaseServices envaseServices)
        {
            _envaseServices = envaseServices;
        }

        [HttpGet]
        public List<Envase> GetEnvases()
        {
            return _envaseServices.GetAll();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(HttpMessage))]
        public ActionResult<Envase> GetEnvase(int id)
        {
            try
            {
                return _envaseServices.GetOneById(id);
            }
            catch (HttpError ex)
            {
                return StatusCode((int)ex.StatusCode, new HttpMessage(ex.Message));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new HttpMessage("Algo salió mal"));
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Envase))]
        public ActionResult Create([FromBody] CreateEnvaseDTO envase)
        {
            var envaseCreated = _envaseServices.CreateOne(envase);
            return Created("api/envases", envaseCreated);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Envase))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(HttpMessage))]
        public ActionResult<Envase> Update(int id, [FromBody] UpdateEnvaseDTO envase)
        {
            try
            {
                return _envaseServices.UpdateOneById(id, envase);
            }
            catch (HttpError ex)
            {
                return StatusCode((int)ex.StatusCode, new HttpMessage(ex.Message));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new HttpMessage($"Algo salió mal actualizando el envase con ID = {id}"));
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(HttpMessage))]
        public ActionResult Delete(int id)
        {
            try
            {
                _envaseServices.DeleteOneById(id);
                return Ok(new HttpMessage($"Envase con ID = {id} eliminado correctamente."));
            }
            catch (HttpError ex)
            {
                return StatusCode((int)ex.StatusCode, new HttpMessage(ex.Message));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new HttpMessage($"Algo salió mal eliminando el envase con ID = {id}"));
            }
        }
    }
}
