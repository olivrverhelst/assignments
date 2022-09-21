using System;
using System.Collections.Generic;

namespace UiS.Dat240.Lab2
{
    public interface IFoodItemValidator
    {
        string[] IsValid(FoodItem foodItem);
    }

    public class FoodItemValidator : IFoodItemValidator
    {

        public string[] IsValid(FoodItem foodItem)
        {
            var list = new List<String>();
            //Tre if-sjekker validation
            if (String.IsNullOrWhiteSpace(foodItem.Description))
            {
                list.Add("Description can't be empty'");
            }
            if (String.IsNullOrWhiteSpace(foodItem.Name))
            {
                list.Add("Name can't be empty");
            }
            if (foodItem.Price <= 0)
            {
                list.Add("Price can't be negative");
            }

            return list.ToArray();
        }
    }
}

