namespace ClyvoDayApiDocker.Models
{
    public class EventoCuidado
    {
        public int EventoCuidadoId { get; private set; }
        public int AnimalEstimacaoId { get; private set; }
        public AnimalEstimacao? AnimalEstimacao { get; private set; }
        public string TypeEvent { get; private set; }
        public string Description { get; private set; }
        public DateTime EventDate { get; private set; }
        public bool EventCompleted { get; private set; }
        public string Observations { get; private set; }


        protected EventoCuidado() { }

        public EventoCuidado(int animalEstimacaoId, string typeEvent, string description, DateTime eventDate, bool eventCompleted, string observations)
        {
            AnimalEstimacaoId = animalEstimacaoId;
            TypeEvent = typeEvent;
            Description = description;
            EventDate = eventDate;
            EventCompleted = eventCompleted;
            Observations = observations;
        }
    }
}
