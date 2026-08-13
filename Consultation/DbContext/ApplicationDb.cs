using Consultation.Model.Entites;
using Microsoft.EntityFrameworkCore;

namespace Consultation.Data
{
    public class ApplicationDb : DbContext
    {
        public ApplicationDb(DbContextOptions<ApplicationDb> options) : base(options)
        {
        }

        public DbSet<RegisterPatient> PatientTable { get; set; }
    }
}
