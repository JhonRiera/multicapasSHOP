namespace Microsoft.eShopWeb.PublicApi.Catalog;

public class catalogoProd
{
    public int id { get; set; }
    public required string producto { get; set; }
    public int idCiudad { get; set; }
    public required string ciudad { get; set; }
}
