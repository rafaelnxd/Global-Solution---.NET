using GlobalSolution.DTOs;
using GlobalSolution.DTOs.ConfiguracaoAutomacao;
using GlobalSolution.Models;
using GlobalSolution.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracoesAutomacaoController : ControllerBase
    {
        private readonly IRepository<ConfiguracaoAutomacao> _configuracaoAutomacaoRepository;

        public ConfiguracoesAutomacaoController(IRepository<ConfiguracaoAutomacao> configuracaoAutomacaoRepository)
        {
            _configuracaoAutomacaoRepository = configuracaoAutomacaoRepository;
        }

        // GET: api/ConfiguracoesAutomacao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfiguracaoAutomacaoReadDTO>>> GetConfiguracoesAutomacao()
        {
            var configuracoes = await _configuracaoAutomacaoRepository.GetAllAsync();
            var configuracaoDTOs = new List<ConfiguracaoAutomacaoReadDTO>();

            foreach (var configuracao in configuracoes)
            {
                configuracaoDTOs.Add(new ConfiguracaoAutomacaoReadDTO
                {
                    Id = configuracao.Id,
                    UsuarioId = configuracao.UsuarioId,
                    DispositivoId = configuracao.DispositivoId,
                    CondicaoAtivacao = configuracao.CondicaoAtivacao,
                    Acao = configuracao.Acao,
                    DataCriacao = configuracao.DataCriacao
                });
            }

            return Ok(configuracaoDTOs);
        }

        // GET: api/ConfiguracoesAutomacao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConfiguracaoAutomacaoReadDTO>> GetConfiguracaoAutomacao(int id)
        {
            var configuracao = await _configuracaoAutomacaoRepository.GetByIdAsync(id);

            if (configuracao == null)
            {
                return NotFound();
            }

            var configuracaoDTO = new ConfiguracaoAutomacaoReadDTO
            {
                Id = configuracao.Id,
                UsuarioId = configuracao.UsuarioId,
                DispositivoId = configuracao.DispositivoId,
                CondicaoAtivacao = configuracao.CondicaoAtivacao,
                Acao = configuracao.Acao,
                DataCriacao = configuracao.DataCriacao
            };

            return Ok(configuracaoDTO);
        }

        // POST: api/ConfiguracoesAutomacao
        [HttpPost]
        public async Task<ActionResult<ConfiguracaoAutomacaoReadDTO>> PostConfiguracaoAutomacao(ConfiguracaoAutomacaoCreateDTO configuracaoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var configuracao = new ConfiguracaoAutomacao
            {
                UsuarioId = configuracaoDTO.UsuarioId,
                DispositivoId = configuracaoDTO.DispositivoId,
                CondicaoAtivacao = configuracaoDTO.CondicaoAtivacao,
                Acao = configuracaoDTO.Acao,
                DataCriacao = DateTime.Now
            };

            var createdConfiguracao = await _configuracaoAutomacaoRepository.AddAsync(configuracao);

            var configuracaoReadDTO = new ConfiguracaoAutomacaoReadDTO
            {
                Id = createdConfiguracao.Id,
                UsuarioId = createdConfiguracao.UsuarioId,
                DispositivoId = createdConfiguracao.DispositivoId,
                CondicaoAtivacao = createdConfiguracao.CondicaoAtivacao,
                Acao = createdConfiguracao.Acao,
                DataCriacao = createdConfiguracao.DataCriacao
            };

            return CreatedAtAction(nameof(GetConfiguracaoAutomacao), new { id = configuracaoReadDTO.Id }, configuracaoReadDTO);
        }

        // PUT: api/ConfiguracoesAutomacao/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfiguracaoAutomacao(int id, ConfiguracaoAutomacaoUpdateDTO configuracaoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }

            var configuracaoExistente = await _configuracaoAutomacaoRepository.GetByIdAsync(id);
            if (configuracaoExistente == null)
            {
                return NotFound();
            }

            configuracaoExistente.UsuarioId = configuracaoDTO.UsuarioId;
            configuracaoExistente.DispositivoId = configuracaoDTO.DispositivoId;
            configuracaoExistente.CondicaoAtivacao = configuracaoDTO.CondicaoAtivacao;
            configuracaoExistente.Acao = configuracaoDTO.Acao;

            await _configuracaoAutomacaoRepository.UpdateAsync(configuracaoExistente);

            return NoContent();
        }

        // DELETE: api/ConfiguracoesAutomacao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfiguracaoAutomacao(int id)
        {
            var deleted = await _configuracaoAutomacaoRepository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
