using GlobalSolution.DTOs;
using GlobalSolution.DTOs.AlertaNotificacao;
using GlobalSolution.Models;
using GlobalSolution.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertasNotificacoesController : ControllerBase
    {
        private readonly IRepository<AlertaNotificacao> _alertaNotificacaoRepository;

        public AlertasNotificacoesController(IRepository<AlertaNotificacao> alertaNotificacaoRepository)
        {
            _alertaNotificacaoRepository = alertaNotificacaoRepository;
        }

        // GET: api/AlertasNotificacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlertaNotificacaoReadDTO>>> GetAlertasNotificacoes()
        {
            var alertas = await _alertaNotificacaoRepository.GetAllAsync();
            var alertaDTOs = new List<AlertaNotificacaoReadDTO>();

            foreach (var alerta in alertas)
            {
                alertaDTOs.Add(new AlertaNotificacaoReadDTO
                {
                    Id = alerta.Id,
                    UsuarioId = alerta.UsuarioId,
                    TipoAlerta = alerta.TipoAlerta,
                    Mensagem = alerta.Mensagem,
                    DataHora = alerta.DataHora
                });
            }

            return Ok(alertaDTOs);
        }

        // GET: api/AlertasNotificacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlertaNotificacaoReadDTO>> GetAlertaNotificacao(int id)
        {
            var alerta = await _alertaNotificacaoRepository.GetByIdAsync(id);

            if (alerta == null)
            {
                return NotFound();
            }

            var alertaDTO = new AlertaNotificacaoReadDTO
            {
                Id = alerta.Id,
                UsuarioId = alerta.UsuarioId,
                TipoAlerta = alerta.TipoAlerta,
                Mensagem = alerta.Mensagem,
                DataHora = alerta.DataHora
            };

            return Ok(alertaDTO);
        }

        // POST: api/AlertasNotificacoes
        [HttpPost]
        public async Task<ActionResult<AlertaNotificacaoReadDTO>> PostAlertaNotificacao(AlertaNotificacaoCreateDTO alertaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alerta = new AlertaNotificacao
            {
                UsuarioId = alertaDTO.UsuarioId,
                TipoAlerta = alertaDTO.TipoAlerta,
                Mensagem = alertaDTO.Mensagem,
                DataHora = System.DateTime.Now // Define a data/hora atual
            };

            var createdAlerta = await _alertaNotificacaoRepository.AddAsync(alerta);

            var alertaReadDTO = new AlertaNotificacaoReadDTO
            {
                Id = createdAlerta.Id,
                UsuarioId = createdAlerta.UsuarioId,
                TipoAlerta = createdAlerta.TipoAlerta,
                Mensagem = createdAlerta.Mensagem,
                DataHora = createdAlerta.DataHora
            };

            return CreatedAtAction(nameof(GetAlertaNotificacao), new { id = alertaReadDTO.Id }, alertaReadDTO);
        }

        // PUT: api/AlertasNotificacoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlertaNotificacao(int id, AlertaNotificacaoUpdateDTO alertaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alertaExistente = await _alertaNotificacaoRepository.GetByIdAsync(id);
            if (alertaExistente == null)
            {
                return NotFound();
            }

            alertaExistente.UsuarioId = alertaDTO.UsuarioId;
            alertaExistente.TipoAlerta = alertaDTO.TipoAlerta;
            alertaExistente.Mensagem = alertaDTO.Mensagem;
            // DataHora não é atualizada via DTO

            await _alertaNotificacaoRepository.UpdateAsync(alertaExistente);

            return NoContent();
        }

        // DELETE: api/AlertasNotificacoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlertaNotificacao(int id)
        {
            var deleted = await _alertaNotificacaoRepository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
