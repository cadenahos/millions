namespace backend.Core;

public class PropertyDTO
{
    public string IdProperty { get; set; }
    public string Name { get; set; }
    public PropertyImageEntity? Image { get; set; }
    public string? Address { get; set; }
    public int Price { get; set; }
    public int Year { get; set; }
    // public Guid IdOwner { get; set; }
}
