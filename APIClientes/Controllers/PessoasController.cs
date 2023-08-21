using APIClientes.Dominio;
using APIClientes.DTOs;
using APIClientes.Repositorio.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIClientes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;

        public PessoasController(IUnityOfWork unityOfWork, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaDTO>>> GetObterPessoas()
        {
            var pessoas = await _unityOfWork.PessoaRepositorio.Get().ToListAsync();
            if (pessoas == null || pessoas.Count == 0)
            {
                return NotFound("Não existem pessoas cadastradas");
            }
            var pessoasDto = _mapper.Map<IEnumerable<Pessoa>>(pessoas);
            return Ok(pessoasDto);
        }

        [HttpGet("CPF/{cpf}")]
        public async Task<ActionResult<PessoaDTO>> GetPessoaPeloCPF(string cpf)
        {
            var pessoaDto = new PessoaDTO();
            pessoaDto.CPF = cpf;

            var pessoa = await _unityOfWork.PessoaRepositorio.GetByID(p => p.CPF == pessoaDto.CPF);

            if (pessoa == null)
            {
                return NotFound("CPF não encontrado");
            }
            var pessoaDTO = _mapper.Map<PessoaDTO>(pessoa);
            return Ok(pessoaDTO);
        }

        [HttpPost]
        public async Task<ActionResult> PostInserirPessoa(PessoaDTO pessoaDto)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaDto);
            if (pessoa is null)
            {
                return BadRequest("Não foi possível realizar o cadastro");
            }

            if (!await _unityOfWork.PessoaRepositorio.AdicionarPessoaSeNaoExistir(pessoa))
            {
                return Conflict("Pessoa já cadastrada");
            }
            await _unityOfWork.Commit();

            var pessoaDTO = _mapper.Map<PessoaDTO>(pessoa);
            return Ok(pessoaDTO);

        }
    }
}
