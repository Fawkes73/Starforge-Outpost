using System;
using System.Collections;
using UnityEngine;
using StarforgeOutpost.Data;
using StarforgeOutpost.Inventory;

namespace StarforgeOutpost.Crafting
{
    public class CraftingSystem : MonoBehaviour
    {
        public event Action<RecipeDataSO, CraftedItemInstance> OnCraftCompleted;

        public void Craft(RecipeDataSO recipe, Color? chosenColor)
        {
            if (recipe == null)
            {
                return;
            }

            if (!InventorySystem.Instance.HasResources(recipe.inputCosts))
            {
                return;
            }

            StartCoroutine(CraftRoutine(recipe, chosenColor));
        }

        private IEnumerator CraftRoutine(RecipeDataSO recipe, Color? chosenColor)
        {
            InventorySystem.Instance.ConsumeResources(recipe.inputCosts);
            yield return new WaitForSeconds(recipe.craftTime);

            Color finalColor = recipe.outputItem != null ? recipe.outputItem.defaultColor : Color.white;
            if (recipe.allowColorCustomization && chosenColor.HasValue)
            {
                finalColor = chosenColor.Value;
            }

            CraftedItemInstance craftedItem = new CraftedItemInstance(recipe.outputItem, finalColor);
            InventorySystem.Instance.AddCraftedItem(craftedItem, recipe.outputAmount);
            OnCraftCompleted?.Invoke(recipe, craftedItem);
        }
    }
}
