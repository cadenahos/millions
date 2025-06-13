namespace backend.Core;

public class PropertyImage
{
    public Guid IdPropertyImage { get; set; }
    public Guid IdProperty { get; set; }
    public string Url { get; set; }
    public bool Enabled { get; set; }
}
