namespace HeroesSqlDb.Entity
{
    public class Hero
    {
        public int Id { get; set; } 
        public string Name { get; set; } = null!;
        public string Power { get; set; } = null!;
        public bool Weatherboost { get; set; }
    }
}
