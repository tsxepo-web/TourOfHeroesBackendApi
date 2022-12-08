namespace HeroesDB.Entity
{
    public class Hero
    {
        public int Id { get; set; } 
        public string? Name { get; set; } = null!;
        public string? Power { get; set; }
        public bool Weatherboost { get; set; }
    }
}
