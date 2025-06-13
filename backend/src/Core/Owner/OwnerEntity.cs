namespace backend.Core;

public class Owner
{
    public Guid IdOwner { get; set; }
    public string Name { get; set; }
    public string? Adress { get; set; }
    public string? Photo { get; set; }
    public DateTime? Birthday { get; set; }
}
