using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UiS.Dat240.Lab2.Pages;

public class AddModel : PageModel
{
    private readonly ILogger<AddModel> _logger;


    public AddModel(ILogger<AddModel> logger, IFoodItemProvider provider)
    {
        _logger = logger;
        _provider = provider;

    }

    private readonly IFoodItemProvider _provider;

    private readonly IFoodItemValidator _validator;

    public FoodItem foodItem = new FoodItem();

    public string[] validator = new string[0];
    public void OnGet()
    {
        var Id = Request.Form["id"];
        _provider.GetFoodItem(Int32.Parse(Id));
    }
    public void onPost()
    {
        var Name = Request.Form["name"];
        var Description = Request.Form["description"];
        var CookTime = Request.Form["cooktime"];
        var Price = Request.Form["price"];

        var NewFoodItem = new FoodItem();
        NewFoodItem.Name = Name;
        NewFoodItem.Description = Description;
        if (CookTime != "")
        {
            NewFoodItem.CookTime = Int32.Parse(CookTime);
        }
        if (Price != "")
        {
            NewFoodItem.Price = Convert.ToDouble(Price);
        }

        _provider.AddFoodItem(NewFoodItem);

    }



}
