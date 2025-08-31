using Microsoft.EntityFrameworkCore;
using Secure_Note_Taking_Api.Models;


namespace Secure_Note_Taking_Api.Data
{
    public class SecureNoteDbContext: DbContext
    {
        public SecureNoteDbContext(DbContextOptions<SecureNoteDbContext> options) : base(options)
        {
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<NoteModel> Notes { get; set; }
    }
    
}
