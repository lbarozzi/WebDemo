namespace _202303325web.Models;
using Microsoft.EntityFrameworkCore;

public class Anag {
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}

public class DataContext :DbContext{
    public DataContext(DbContextOptions opt): base(opt) {
        this.Database.Migrate();
    }
    public virtual DbSet<Anag>  Anags{get;set;}
}