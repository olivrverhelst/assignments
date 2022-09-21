using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UiS.Dat240.Lab2.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IFoodItemProvider _provider;

    // public IndexModel(ILogger<IndexModel> logger, IFoodItemProvider provider)
    // {
    //     _logger = logger;
    //     _provider = provider;

    // }
    private readonly IFoodItemValidator _validator;
    public string[] validator = new string[0];

    // public void OnGet()
    // {
    //     _provider.GetItems();

    // }
}