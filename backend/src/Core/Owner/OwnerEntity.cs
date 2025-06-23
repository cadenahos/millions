namespace backend.Core;

public class Owner
{
    public string IdOwner { get; set; }
    public string Name { get; set; }
    public string? Adress { get; set; }
    public string? Photo { get; set; }
    public DateTime? Birthday { get; set; }

    public Owner(string idOwner, string name, string? adress, string? photo, DateTime? birthday)
    {
        IdOwner = idOwner;
        Name = name;
        Adress = adress;
        Photo = photo;
        Birthday = birthday;
    }
}
