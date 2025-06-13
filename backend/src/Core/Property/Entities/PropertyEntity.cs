namespace backend.Core;

public class PropertyEntity
{
    public Guid IdProperty { get; set; }
    public Guid IdOwner { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int Price { get; set; }
    public string CodeInternal { get; set; }
    public int Year { get; set; }
}
