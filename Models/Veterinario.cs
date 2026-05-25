using System.Text.Json.Serialization;

namespace ClyvoDayApiDocker.Models
{
    public class Veterinario
    {
        public int VeterinarioId { get; private set; }
        public string FullName { get; private set; }
        public string Crmv { get; private set; }
        public string Specialty { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        [JsonIgnore]
        public Clinica? Clinica { get; private set; }
        public int ClinicaId { get; private set; }

        protected Veterinario() { }

        public Veterinario(string fullName, string crmv, string specialty, string email, string phoneNumber, int clinicaId)
        {
            FullName = fullName;
            Crmv = crmv;
            Specialty = specialty;
            Email = email;
            PhoneNumber = phoneNumber;
            ClinicaId = clinicaId;
        }

        public void UpdateContact(string email, string phoneNumber)
        {
            Email = email;
            PhoneNumber = phoneNumber;
        }


        public void UpdateSpecialty(string specialty)
        {
            Specialty = specialty;
        }
    }
}
