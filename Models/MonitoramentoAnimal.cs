namespace ClyvoDayApiDocker.Models
{
    public class MonitoramentoAnimal
    {
        public int MonitoramentoAnimalId { get; private set; }
        public int AnimalEstimacaoId { get; private set; }
        public AnimalEstimacao? AnimalEstimacao { get; private set; }
        public string Mood { get; private set; }
        public string EnergyLevel { get; private set; }
        public string Food { get; private set; }
        public string SleepQuality { get; private set; }
        public string RecentActivities { get; private set; }
        public bool Medication { get; private set; }
        public string Observations { get; private set; }
        public DateTime MonitoringDate { get; private set; }


        protected MonitoramentoAnimal() { }

        public MonitoramentoAnimal(int animalEstimacaoId, string mood, string energyLevel, string food, string sleepQuality, string recentActivities, bool medication, string observations)
        {
            AnimalEstimacaoId = animalEstimacaoId;
            Mood = mood;
            EnergyLevel = energyLevel;
            Food = food;
            SleepQuality = sleepQuality;
            RecentActivities = recentActivities;
            Medication = medication;
            Observations = observations;
            MonitoringDate = DateTime.UtcNow;
        }
    }
}
