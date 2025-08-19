    using METABack.Entities;
using METABack.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace METABack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NomenclatureSignalisationController : ControllerBase
    {
        private readonly INomenclatureSignalisation _INomenclatureSignalisation;

        public NomenclatureSignalisationController(INomenclatureSignalisation INomenclatureSignalisation)
        {
            _INomenclatureSignalisation = INomenclatureSignalisation;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NomenclatureSignalisation>>> Get()
        {
            return await Task.FromResult(_INomenclatureSignalisation.GetSignalisationList());
        }

        [HttpGet("informateurs")]
        public async Task<ActionResult<IEnumerable<NomenclatureInformateur>>> GetInformateurs()
        {
            return await Task.FromResult(_INomenclatureSignalisation.GetInformateurList());
        }

        
        [HttpGet("concernes")]
        public async Task<ActionResult<IEnumerable<NomenclatureConcerne>>> GetConcernes()
        {
            return await Task.FromResult(_INomenclatureSignalisation.GetConcerneList());
        }

        [HttpPost("add")]
        public async Task<ActionResult<NomenclatureSignalisation>> Post(NomenclatureSignalisation signalisation)
        {
            signalisation.Acti = true;
            signalisation.CodeStatus = "0";
            signalisation.MethodeSignalisation = "0";
            signalisation.DateSignalisation = DateTime.Now;
            signalisation.DateDepot = DateTime.Now;
            _INomenclatureSignalisation.AddSignalisation(signalisation);
            return await Task.FromResult(signalisation);
        }
    }
}
