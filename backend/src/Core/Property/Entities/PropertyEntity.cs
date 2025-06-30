namespace backend.Core;

public class PropertyEntity
{
    public string IdProperty { get; set; }
    public Owner Owner { get; set; }
    public ICollection<PropertyImageEntity> Images { get; set; }
    public PropertyTraceEntity Trace { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int Price { get; set; }
    public string CodeInternal { get; set; }
    public int Year { get; set; }

    public PropertyDTO ToDTO()
    {
        return new PropertyDTO
        {
            IdProperty = IdProperty,
            Name = Name,
            Address = Address,
            Price = Price,
            Year = Year,
            Image = Images.FirstOrDefault(),
        };
    }

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
