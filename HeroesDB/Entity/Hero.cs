namespace HeroesSqlDb.Entity;

public class Hero
{
    public int Id { get; set; } 
    public string? Name { get; set; }
    public Powers Powers { get; set; }
    public int[]? Weatherboost { get; set; }
    public int PowerLevel {get; set;}
    public bool IsVillain {get; set;}
}
