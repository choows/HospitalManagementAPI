using Microsoft.EntityFrameworkCore;

namespace HospitalManagementAPI.Models
{
    public class HospitalManagementContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public HospitalManagementContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("HospitalManagementContext"));
        }
        public DbSet<Appointment> _appointments { get; set; } = null!;
        public DbSet<Doctor> _doctors { get; set; } = null!;
        public DbSet<Medicine> _medicines { get; set; } = null!;
        public DbSet<Patient> _patients { get; set; } = null!;
        public DbSet<PatientHistory> _patientHistory { get; set; } = null!;
        public DbSet<Pharmacist> _pharmacists { get; set; } = null!;
        public DbSet<Admin> _admins { get; set; } = null!;
        public DbSet<Prescription> _prescriptions { get; set; } = null!;
        public DbSet<RoleModel> _roleModels { get; set; } = null!;
        public DbSet<UserModal> _userModels { get; set; } = null!;
        public DbSet<NonPatientAppointment> _nonPatientAppointments { get; set; } = null!;
        public HospitalManagementContext(DbContextOptions<HospitalManagementContext> options) : base(options)
        {
        }
    }
}
