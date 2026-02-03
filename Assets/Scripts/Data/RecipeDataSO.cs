using System.Collections.Generic;
using UnityEngine;

namespace StarforgeOutpost.Data
{
    [CreateAssetMenu(menuName = "Starforge Outpost/Recipe Data", fileName = "NewRecipeData")]
    public class RecipeDataSO : ScriptableObject
    {
        public string recipeId;
        public ItemDataSO outputItem;
        public int outputAmount = 1;
        public float craftTime = 2f;
        public bool allowColorCustomization = true;
        public List<Color> presetColors = new List<Color>();
        public List<ResourceAmount> inputCosts = new List<ResourceAmount>();
    }
}
