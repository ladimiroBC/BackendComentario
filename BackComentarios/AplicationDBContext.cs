using BackComentarios.Controllers.Models;
using Microsoft.EntityFrameworkCore;

namespace BackComentarios
{
    public class AplicationDBContext: DbContext
    {
        public DbSet<Comentario> Comentario { get; set; }

        public AplicationDBContext(DbContextOptions<AplicationDBContext> options): base(options)
        {

        }
    }
}
