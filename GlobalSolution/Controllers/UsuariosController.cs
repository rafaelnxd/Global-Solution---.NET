using GlobalSolution.DTOs;
using GlobalSolution.DTOs.Usuario;
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
    public class UsuariosController : ControllerBase
    {
        private readonly IRepository<Usuario> _usuarioRepository;

        public UsuariosController(IRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioReadDTO>>> GetUsuarios()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();

            var usuarioDTOs = new List<UsuarioReadDTO>();
            foreach (var usuario in usuarios)
            {
                usuarioDTOs.Add(new UsuarioReadDTO
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    TipoConta = usuario.TipoConta,
                    DataRegistro = usuario.DataRegistro
                });
            }

            return Ok(usuarioDTOs);
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioReadDTO>> GetUsuario(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            var usuarioDTO = new UsuarioReadDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                TipoConta = usuario.TipoConta,
                DataRegistro = usuario.DataRegistro
            };

            return Ok(usuarioDTO);
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<UsuarioReadDTO>> PostUsuario(UsuarioCreateDTO usuarioDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = new Usuario
            {
                Nome = usuarioDTO.Nome,
                Email = usuarioDTO.Email,
                TipoConta = usuarioDTO.TipoConta,
                DataRegistro = DateTime.Now
            };

            var createdUsuario = await _usuarioRepository.AddAsync(usuario);

            var usuarioReadDTO = new UsuarioReadDTO
            {
                Id = createdUsuario.Id,
                Nome = createdUsuario.Nome,
                Email = createdUsuario.Email,
                TipoConta = createdUsuario.TipoConta,
                DataRegistro = createdUsuario.DataRegistro
            };

            return CreatedAtAction(nameof(GetUsuario), new { id = usuarioReadDTO.Id }, usuarioReadDTO);
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioUpdateDTO usuarioDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }

            var usuarioExistente = await _usuarioRepository.GetByIdAsync(id);
            if (usuarioExistente == null)
            {
                return NotFound();
            }

            usuarioExistente.Nome = usuarioDTO.Nome;
            usuarioExistente.Email = usuarioDTO.Email;
            usuarioExistente.TipoConta = usuarioDTO.TipoConta;

            await _usuarioRepository.UpdateAsync(usuarioExistente);

            return NoContent();
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var deleted = await _usuarioRepository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
