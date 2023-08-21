using APICobrancas.Dominio;
using APICobrancas.DTOs;
using APICobrancas.Repositorio.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIClientes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CobrancasController : ControllerBase
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;

        public CobrancasController(IUnityOfWork unityOfWork, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }

        [HttpGet("CPF/{cpf}")]
        public async Task<ActionResult<IEnumerable<CobrancaDTO>>> GetObterCobrancasPorCPF(string cpf)
        {
            var cobrancas = await _unityOfWork.CobrancaRepositorio.Get().Where(p => p.CPF == cpf).ToListAsync();
            if (cobrancas == null || cobrancas.Count == 0)
            {
                return NotFound("Não existem cobranças para o CPF informado");
            }
            var cobrancasDto = _mapper.Map<IEnumerable<CobrancaDTO>>(cobrancas);
            return Ok(cobrancasDto);
        }

        [HttpGet("Vencimento/{mes:int}")]
        public async Task<ActionResult<IEnumerable<CobrancaDTO>>> GetObterCobrancasPorMes(int mes)
        {
            var cobrancas = await _unityOfWork.CobrancaRepositorio.Get().Where(p => p.DataVencimento.Month ==  mes).ToListAsync();
            if (cobrancas == null || cobrancas.Count == 0)
            {
                return NotFound("Não existem cobranças para o mês informado");
            }
            var cobrancasDto = _mapper.Map<IEnumerable<CobrancaDTO>> (cobrancas);
            return Ok(cobrancasDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CobrancaDTO cobrancaDto)
        {           
            var cobranca = _mapper.Map<Cobranca>(cobrancaDto);

            if (cobranca is null)
            {
                return BadRequest("Não foi possível incluir a cobrança");
            }
            _unityOfWork.CobrancaRepositorio.Add(cobranca);
            await _unityOfWork.Commit();

            return Ok(cobrancaDto);
        }
    }
}
