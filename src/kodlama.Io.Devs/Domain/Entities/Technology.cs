using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Technology : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ProgrammingLanguage ProgrammingLanguage { get; set; }
}