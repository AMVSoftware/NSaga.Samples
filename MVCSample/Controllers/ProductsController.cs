using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MVCSample.Models;



namespace MVCSample.Controllers
{
	public class ProductsController : Controller
	{
	    private readonly ApplicationDbContext context;

	    public ProductsController(ApplicationDbContext context)
	    {
	        this.context = context;
	    }


	    public ActionResult Index()
	    {
	        var products = context.Products.AsNoTracking().ToList();

	        return View(products);
	    }
	}
}