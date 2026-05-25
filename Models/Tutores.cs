namespace ClyvoDayApiDocker.Models
{
    public class Tutores
    {
        public int TutoresId { get; private set; }
        public string FullName { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string PhoneNumber { get; private set; }
        public int ScoreEngagement { get; private set; }
        public ICollection<AnimalEstimacao> AnimaisEstimacao { get; private set; }



        protected Tutores()
        {

            AnimaisEstimacao = new List<AnimalEstimacao>();

        }

        public Tutores(string fullName, string cpf, string email, string password, string phoneNumber)
        {
            FullName = fullName;
            Cpf = cpf;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            ScoreEngagement = 0;
            AnimaisEstimacao = new List<AnimalEstimacao>();
        }

        public void UpdateScore(int points)
        {
            ScoreEngagement += points;
        }

        public void UpdateContact(string email, string phoneNumber)
        {
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
