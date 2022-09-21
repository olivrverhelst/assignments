using Microsoft.AspNetCore.Mvc.RazorPages;
// kommentarer
namespace UiS.Dat240.Lab2.Pages;

public class EditModel : PageModel
{
    private readonly ILogger<EditModel> _logger;


    // public EditModel(ILogger<EditModel> logger, IFoodItemProvider provider)
    // {
    //     _logger = logger;
    //     _provider = provider;

    // }

    private readonly IFoodItemProvider _provider;

    private readonly IFoodItemValidator _validator;

    public FoodItem foodItem = new FoodItem();

    public string[] validator = new string[0];
    // public void OnGet()
    // {
    //     var Id = Request.Form["id"];
    //     _provider.GetFoodItem(Int32.Parse(Id));
    // }
    public void onPost()
    {
        var Id = Request.Form["id"];
        var Name = Request.Form["name"];
        var Description = Request.Form["description"];
        var CookTime = Request.Form["cooktime"];
        var Price = Request.Form["price"];

        var UpdatedFoodItem = new FoodItem();

        UpdatedFoodItem.Id = Int32.Parse(Id);
        UpdatedFoodItem.Name = Name;
        UpdatedFoodItem.Description = Description;
        if (CookTime != "")
        {
            UpdatedFoodItem.CookTime = Int32.Parse(CookTime);
        }
        if (Price != "")
        {
            UpdatedFoodItem.Price = Convert.ToDouble(Price);
        }

        _provider.UpdateFoodItem(UpdatedFoodItem.Id, UpdatedFoodItem);

    }



}