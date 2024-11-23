using GlobalSolution.DTOs;
using GlobalSolution.DTOs.Dispositivo;
using GlobalSolution.Models;
using GlobalSolution.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispositivosController : ControllerBase
    {
        private readonly IRepository<Dispositivo> _dispositivoRepository;

        public DispositivosController(IRepository<Dispositivo> dispositivoRepository)
        {
            _dispositivoRepository = dispositivoRepository;
        }

        // GET: api/Dispositivos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DispositivoReadDTO>>> GetDispositivos()
        {
            var dispositivos = await _dispositivoRepository.GetAllAsync();

            var dispositivoDTOs = new List<DispositivoReadDTO>();
            foreach (var dispositivo in dispositivos)
            {
                dispositivoDTOs.Add(new DispositivoReadDTO
                {
                    Id = dispositivo.Id,
                    NomeDispositivo = dispositivo.NomeDispositivo,
                    TipoDispositivo = dispositivo.TipoDispositivo,
                    Localizacao = dispositivo.Localizacao,
                    UsuarioId = dispositivo.UsuarioId
                });
            }

            return Ok(dispositivoDTOs);
        }

        // GET: api/Dispositivos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DispositivoReadDTO>> GetDispositivo(int id)
        {
            var dispositivo = await _dispositivoRepository.GetByIdAsync(id);

            if (dispositivo == null)
            {
                return NotFound();
            }

            var dispositivoDTO = new DispositivoReadDTO
            {
                Id = dispositivo.Id,
                NomeDispositivo = dispositivo.NomeDispositivo,
                TipoDispositivo = dispositivo.TipoDispositivo,
                Localizacao = dispositivo.Localizacao,
                UsuarioId = dispositivo.UsuarioId
            };

            return Ok(dispositivoDTO);
        }

        // POST: api/Dispositivos
        [HttpPost]
        public async Task<ActionResult<DispositivoReadDTO>> PostDispositivo(DispositivoCreateDTO dispositivoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dispositivo = new Dispositivo
            {
                NomeDispositivo = dispositivoDTO.NomeDispositivo,
                TipoDispositivo = dispositivoDTO.TipoDispositivo,
                Localizacao = dispositivoDTO.Localizacao,
                UsuarioId = dispositivoDTO.UsuarioId
            };

            var createdDispositivo = await _dispositivoRepository.AddAsync(dispositivo);

            var dispositivoReadDTO = new DispositivoReadDTO
            {
                Id = createdDispositivo.Id,
                NomeDispositivo = createdDispositivo.NomeDispositivo,
                TipoDispositivo = createdDispositivo.TipoDispositivo,
                Localizacao = createdDispositivo.Localizacao,
                UsuarioId = createdDispositivo.UsuarioId
            };

            return CreatedAtAction(nameof(GetDispositivo), new { id = dispositivoReadDTO.Id }, dispositivoReadDTO);
        }

        // PUT: api/Dispositivos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDispositivo(int id, DispositivoUpdateDTO dispositivoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dispositivoExistente = await _dispositivoRepository.GetByIdAsync(id);
            if (dispositivoExistente == null)
            {
                return NotFound();
            }

            dispositivoExistente.NomeDispositivo = dispositivoDTO.NomeDispositivo;
            dispositivoExistente.TipoDispositivo = dispositivoDTO.TipoDispositivo;
            dispositivoExistente.Localizacao = dispositivoDTO.Localizacao;
            dispositivoExistente.UsuarioId = dispositivoDTO.UsuarioId;

            await _dispositivoRepository.UpdateAsync(dispositivoExistente);

            return NoContent();
        }

        // DELETE: api/Dispositivos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDispositivo(int id)
        {
            var deleted = await _dispositivoRepository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
