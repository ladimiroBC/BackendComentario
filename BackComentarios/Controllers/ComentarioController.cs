using BackComentarios.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackComentarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        
        private readonly AplicationDBContext _dbContext;

        public ComentarioController(AplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }



        // GET: api/<ComentarioController>
        [HttpGet]
        public async Task<IActionResult> GetComment()
        {
            try
            {
                var listarComentarios = await _dbContext.Comentario.ToListAsync();
                return Ok(listarComentarios);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ComentarioController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> CommentDetail(int id)
        {
            try
            {
                var comentario = await  _dbContext.Comentario.FindAsync(id);

                if(comentario == null)
                {
                    return NotFound();
                }

                return Ok(comentario);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ComentarioController>
        [HttpPost]
        public async Task<IActionResult> PostComment([FromBody] Comentario comentario)
        {

            try
            {
                _dbContext.Add(comentario);
                await _dbContext.SaveChangesAsync();

                return Ok(comentario);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
        }

        // PUT api/<ComentarioController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, [FromBody] Comentario comentario)
        {

            try
            {
                if (id != comentario.Id)
                {
                    return BadRequest();
                }

                _dbContext.Update(comentario);
                await _dbContext.SaveChangesAsync();
                return Ok(new {mesaage="Comentario actualizado con exito!"});
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ComentarioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            try
            {
                var comentario = await _dbContext.Comentario.FindAsync(id);

                if(comentario == null)
                {
                    return NotFound();
                }

                _dbContext.Comentario.Remove(comentario);
                await _dbContext.SaveChangesAsync();
                return Ok(new { mesaage = "Comentario eliminado con exito!" });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
