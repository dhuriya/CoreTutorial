using CoreLearn.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    public class ViewResultCController : Controller
    {
        // GET: ViewResultCController
        public ViewResult Index()
        {
            ViewResultProduct pr = new ViewResultProduct()
            {
                Id = 1,
                Name="text",
            };
            return View(pr);
        }
        // [AjaxOnly]
        // public PartialViewResult Index2()
        // {
        //     ViewResultProduct pr = new ViewResultProduct()
        //     {
        //         Id = 1,
        //         Name="text",
        //     };
        //     return PartialView("_ProductDetailsPartilaView",pr);
        // }

        //[AjaxOnly]
        public PartialViewResult Index2(int ProductId)
        {
            string method = HttpContext.Request.Method;
            string? requestedWith = HttpContext?.Request?.Headers.XRequestedWith;
            if(method == "POST" || method == "GET")
            {
                if(requestedWith == "XMLHttpRequest")
                {
                    ViewResultProduct pr = new ViewResultProduct()
                    {
                        Id = ProductId,
                        Name="text",
                    };
                    return PartialView("_ProductDetailsPartilaView",pr);       
                }
            }
            return PartialView("_InvalidRequestPartilaView");       
        }

    }
}
