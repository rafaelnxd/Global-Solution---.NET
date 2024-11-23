using GlobalSolution.DTOs.ConsumoEnergia;
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
    public class ConsumoEnergiaController : ControllerBase
    {
        private readonly IRepository<ConsumoEnergia> _consumoEnergiaRepository;

        public ConsumoEnergiaController(IRepository<ConsumoEnergia> consumoEnergiaRepository)
        {
            _consumoEnergiaRepository = consumoEnergiaRepository;
        }

        // GET: api/ConsumoEnergia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsumoEnergiaReadDTO>>> GetConsumosEnergia()
        {
            var consumos = await _consumoEnergiaRepository.GetAllAsync();
            var consumoDTOs = new List<ConsumoEnergiaReadDTO>();

            foreach (var consumo in consumos)
            {
                consumoDTOs.Add(new ConsumoEnergiaReadDTO
                {
                    Id = consumo.Id,
                    DispositivoId = consumo.DispositivoId,
                    DataHora = consumo.DataHora,
                    ConsumoEnergiaKwh = consumo.ConsumoEnergiaKwh,
                    Status = consumo.Status
                });
            }

            return Ok(consumoDTOs);
        }

        // GET: api/ConsumoEnergia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsumoEnergiaReadDTO>> GetConsumoEnergia(int id)
        {
            var consumo = await _consumoEnergiaRepository.GetByIdAsync(id);

            if (consumo == null)
            {
                return NotFound();
            }

            var consumoDTO = new ConsumoEnergiaReadDTO
            {
                Id = consumo.Id,
                DispositivoId = consumo.DispositivoId,
                DataHora = consumo.DataHora,
                ConsumoEnergiaKwh = consumo.ConsumoEnergiaKwh,
                Status = consumo.Status
            };

            return Ok(consumoDTO);
        }

        // POST: api/ConsumoEnergia
        [HttpPost]
        public async Task<ActionResult<ConsumoEnergiaReadDTO>> PostConsumoEnergia(ConsumoEnergiaCreateDTO consumoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var consumo = new ConsumoEnergia
            {
                DispositivoId = consumoDTO.DispositivoId,
                ConsumoEnergiaKwh = consumoDTO.ConsumoEnergiaKwh,
                Status = consumoDTO.Status,
                DataHora = DateTime.Now // Define a data/hora atual
            };

            var createdConsumo = await _consumoEnergiaRepository.AddAsync(consumo);

            var consumoReadDTO = new ConsumoEnergiaReadDTO
            {
                Id = createdConsumo.Id,
                DispositivoId = createdConsumo.DispositivoId,
                DataHora = createdConsumo.DataHora,
                ConsumoEnergiaKwh = createdConsumo.ConsumoEnergiaKwh,
                Status = createdConsumo.Status
            };

            return CreatedAtAction(nameof(GetConsumoEnergia), new { id = consumoReadDTO.Id }, consumoReadDTO);
        }

        // PUT: api/ConsumoEnergia/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsumoEnergia(int id, ConsumoEnergiaUpdateDTO consumoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }

            var consumoExistente = await _consumoEnergiaRepository.GetByIdAsync(id);
            if (consumoExistente == null)
            {
                return NotFound();
            }

            consumoExistente.DispositivoId = consumoDTO.DispositivoId;
            consumoExistente.ConsumoEnergiaKwh = consumoDTO.ConsumoEnergiaKwh;
            consumoExistente.Status = consumoDTO.Status;

            await _consumoEnergiaRepository.UpdateAsync(consumoExistente);

            return NoContent();
        }

        // DELETE: api/ConsumoEnergia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsumoEnergia(int id)
        {
            var deleted = await _consumoEnergiaRepository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
