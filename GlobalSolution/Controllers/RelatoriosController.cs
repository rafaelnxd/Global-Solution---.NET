using GlobalSolution.DTOs;
using GlobalSolution.DTOs.Relatorio;
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
    public class RelatoriosController : ControllerBase
    {
        private readonly IRepository<Relatorio> _relatorioRepository;

        public RelatoriosController(IRepository<Relatorio> relatorioRepository)
        {
            _relatorioRepository = relatorioRepository;
        }

        // GET: api/Relatorios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RelatorioReadDTO>>> GetRelatorios()
        {
            var relatorios = await _relatorioRepository.GetAllAsync();
            var relatorioDTOs = new List<RelatorioReadDTO>();

            foreach (var relatorio in relatorios)
            {
                relatorioDTOs.Add(new RelatorioReadDTO
                {
                    Id = relatorio.Id,
                    UsuarioId = relatorio.UsuarioId,
                    TipoRelatorio = relatorio.TipoRelatorio,
                    DataGeracao = relatorio.DataGeracao,
                    ResumoConsumo = relatorio.ResumoConsumo
                });
            }

            return Ok(relatorioDTOs);
        }

        // GET: api/Relatorios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RelatorioReadDTO>> GetRelatorio(int id)
        {
            var relatorio = await _relatorioRepository.GetByIdAsync(id);

            if (relatorio == null)
            {
                return NotFound();
            }

            var relatorioDTO = new RelatorioReadDTO
            {
                Id = relatorio.Id,
                UsuarioId = relatorio.UsuarioId,
                TipoRelatorio = relatorio.TipoRelatorio,
                DataGeracao = relatorio.DataGeracao,
                ResumoConsumo = relatorio.ResumoConsumo
            };

            return Ok(relatorioDTO);
        }

        // POST: api/Relatorios
        [HttpPost]
        public async Task<ActionResult<RelatorioReadDTO>> PostRelatorio(RelatorioCreateDTO relatorioDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var relatorio = new Relatorio
            {
                UsuarioId = relatorioDTO.UsuarioId,
                TipoRelatorio = relatorioDTO.TipoRelatorio,
                ResumoConsumo = relatorioDTO.ResumoConsumo,
                DataGeracao = DateTime.Now
            };

            var createdRelatorio = await _relatorioRepository.AddAsync(relatorio);

            var relatorioReadDTO = new RelatorioReadDTO
            {
                Id = createdRelatorio.Id,
                UsuarioId = createdRelatorio.UsuarioId,
                TipoRelatorio = createdRelatorio.TipoRelatorio,
                DataGeracao = createdRelatorio.DataGeracao,
                ResumoConsumo = createdRelatorio.ResumoConsumo
            };

            return CreatedAtAction(nameof(GetRelatorio), new { id = relatorioReadDTO.Id }, relatorioReadDTO);
        }

        // PUT: api/Relatorios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRelatorio(int id, RelatorioUpdateDTO relatorioDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var relatorioExistente = await _relatorioRepository.GetByIdAsync(id);
            if (relatorioExistente == null)
            {
                return NotFound();
            }

            relatorioExistente.UsuarioId = relatorioDTO.UsuarioId;
            relatorioExistente.TipoRelatorio = relatorioDTO.TipoRelatorio;
            relatorioExistente.ResumoConsumo = relatorioDTO.ResumoConsumo;

            await _relatorioRepository.UpdateAsync(relatorioExistente);

            return NoContent();
        }

        // DELETE: api/Relatorios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRelatorio(int id)
        {
            var deleted = await _relatorioRepository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
