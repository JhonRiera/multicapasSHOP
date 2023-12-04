using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using Microsoft.eShopWeb.PublicApi.CatalogBrandEndpoints;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints;

[ApiController]
[Route("api/[Controller]")]
public class ListProdLocalidad : ControllerBase
{
    private static List<CatalogoLocalidad> _localidades = new List<CatalogoLocalidad>
    {
        new CatalogoLocalidad { Id = 1, Name = "Quito"},
        new CatalogoLocalidad { Id = 2, Name = "Guayaquil" }
    };

    private static List<CatalogoProducto> _productos = new List<CatalogoProducto>
    {
        new CatalogoProducto { Id = 1, Name = "ROSLYN RED SHEET", IdLocalidad = 1},
        new CatalogoProducto { Id = 2, Name = "NET BOT BLACK SWEATSHIRT", IdLocalidad = 1},
        new CatalogoProducto { Id = 3, Name = ".NET BLUE SWEATSHIRT", IdLocalidad = 1},
        new CatalogoProducto { Id = 4, Name = "CUP WHITE MUG", IdLocalidad = 2},
        new CatalogoProducto { Id = 5, Name = " ROSLYN RED T-SHIRT", IdLocalidad = 2}
    };



    [HttpGet("{id}")]
    public ActionResult<IEnumerable<CatalogoProducto>> GetByLocalidad(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return BadRequest();
        }

        var idLoc = _localidades.Find(x => x.Name == id);
        var prods = _productos.Where(x => x.IdLocalidad == idLoc.Id).FirstOrDefault();

        return Ok(prods);
    }

    [HttpGet]
    public ActionResult<IEnumerable<CatalogoProducto>> GetItems()
    {
        return _productos;
    }
}
