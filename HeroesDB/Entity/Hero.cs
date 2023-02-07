namespace HeroesDB.Entity
{
    public class Hero
    {
        public int Id { get; set; } 
        public string Name { get; set; } = null!;
        public Powers Powers { get; set; }
        public double Weatherboost { get; set; }
        public double PowerLevel { get; set; } 
        public bool IsVillain { get; set; }
    }
}
