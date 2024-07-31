using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.eShopWeb.PublicApi.CatalogBrandEndpoints;

namespace Microsoft.eShopWeb.PublicApi.Catalog;
[Route("api/[controller]")]
[ApiController]
public class ListProdLocalidad : ControllerBase
{
    private static readonly List<Localidad> localidade = new List<Localidad>
        {
            new Localidad { id = 1, nombre = "Quito" },
            new Localidad { id = 2, nombre = "Guayaquil" }
        };

    private static readonly List<catalogoProd> productos = new List<catalogoProd>
        {
            new catalogoProd { id = 1, producto = "ROSLYN RED SHEET", idCiudad = 1, ciudad = "Quito"},
            new catalogoProd { id = 2, producto = ".NET BOT BLACK SWEATSHIRT", idCiudad = 1, ciudad = "Quito"},
            new catalogoProd { id = 3, producto = ".NET BLUE SWEATSHIRT", idCiudad = 1, ciudad = "Quito"},
            new catalogoProd { id = 4, producto = "CUP<T> WHITE MUG", idCiudad = 2, ciudad = "Guayaquil"},
            new catalogoProd { id = 5, producto = "ROSLYN RED T-SHIRT", idCiudad = 2, ciudad = "Guayaquil"}
        };

    /// <summary>
    /// Obtiene todos los productos.
    /// </summary>
    [HttpGet("list-prod")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<catalogoProd>> GetItems()
    {
        return productos;
    }

    /// <summary>
    /// Obtiene los productos por ciudad.
    /// </summary>
    /// <param name="idCiudad">ID de la ciudad.</param>
    [HttpGet("list-prod-by-city")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<catalogoProd>> GetItemsByCity(int idCiudad)
    {
        var productosByCity = productos.Where(p => p.idCiudad == idCiudad).ToList();
        if (!productosByCity.Any())
        {
            return NotFound($"No se encontraron productos para la ciudad con ID {idCiudad}.");
        }
        return productosByCity;
    }

}
