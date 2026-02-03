using System.Collections.Generic;
using UnityEngine;
using StarforgeOutpost.Crafting;
using StarforgeOutpost.Data;

namespace StarforgeOutpost.Buildings
{
    public class CraftingStation : BuildingBase
    {
        [SerializeField] private CraftingSystem craftingSystem;

        public IReadOnlyList<RecipeDataSO> AvailableRecipes
        {
            get
            {
                if (BuildingData == null)
                {
                    return new List<RecipeDataSO>();
                }

                return BuildingData.availableRecipes;
            }
        }

        public void CraftRecipe(RecipeDataSO recipe, Color? chosenColor = null)
        {
            if (craftingSystem == null || recipe == null)
            {
                return;
            }

            craftingSystem.Craft(recipe, chosenColor);
        }
    }
}
