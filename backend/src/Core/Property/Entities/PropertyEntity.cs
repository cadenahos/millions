namespace backend.Core;

public class PropertyEntity
{
    public string IdProperty { get; set; }
    public Owner Owner { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int Price { get; set; }
    public string CodeInternal { get; set; }
    public int Year { get; set; }

    // public Owner(string idOwner, string name, string? adress, string? photo, DateTime? birthday)
    //     {
    //         IdOwner = idOwner;
    //         Name = name;
    //         Adress = adress;
    //         Photo = photo;
    //         Birthday = birthday;
    //     }
    public PropertyEntity(
        string idProperty,
        Owner owner,
        string name,
        string address,
        int price,
        string codeInternal,
        int year
    )
    {
        IdProperty = idProperty;
        Owner = owner;
        Name = name;
        Address = address;
        Price = price;
        CodeInternal = codeInternal;
        Year = year;
    }
}
