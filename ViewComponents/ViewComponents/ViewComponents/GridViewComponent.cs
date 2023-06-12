using Microsoft.AspNetCore.Mvc;
using ViewComponents.Models;

namespace ViewComponents.ViewComponents
{
    public class GridViewComponent : ViewComponent
    {
         public async Task<IViewComponentResult> InvokeAsync(PersonGridModel grid )
        {
            return View("Sample", grid); //invoked a partiel view // a defualt route => Views/Shared/Grid/Default.cshtml
        }
    }
}
