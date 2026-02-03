using UnityEngine;
using StarforgeOutpost.Data;

namespace StarforgeOutpost.Crafting
{
    public class CraftingRecipe : MonoBehaviour
    {
        [SerializeField] private RecipeDataSO recipeData;

        public RecipeDataSO RecipeData => recipeData;
    }
}
