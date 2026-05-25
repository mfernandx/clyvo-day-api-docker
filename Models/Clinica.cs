namespace ClyvoDayApiDocker.Models
{
    public class Clinica
    {
        public int ClinicaId { get; private set; }
        public string TradeName { get; private set; }
        public string Cnpj { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Address { get; private set; }
        public ICollection<Veterinario> Veterinarios { get; private set; }


        protected Clinica()
        {

            Veterinarios = new List<Veterinario>();

        }

        public Clinica(string tradeName, string cnpj, string email, string phoneNumber, string address)
        {
            TradeName = tradeName;
            Cnpj = cnpj;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            Veterinarios = new List<Veterinario>();
        }
    }
}
