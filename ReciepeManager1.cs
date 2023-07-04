using System;
using System.Collections;
using System.Collections.Generic;

namespace DataReciepe
{
    internal class ReciepeManager
    {
        internal IEnumerable Reciepes;

        internal List<Reciepe> FilterReciepesByIngredient(string ingredientName)
        {
            throw new NotImplementedException();
        }

        internal List<Reciepe> FilterRecipesByFoodGroup(string? foodGroup)
        {
            throw new NotImplementedException();
        }

        internal List<Reciepe> FilterRecipesByMaximumCalories(int maxCalories)
        {
            throw new NotImplementedException();
        }
    }
}