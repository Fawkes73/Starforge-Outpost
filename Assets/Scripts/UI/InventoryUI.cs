using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarforgeOutpost.Data;
using StarforgeOutpost.Inventory;

namespace StarforgeOutpost.UI
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private List<ItemDataSO> trackedResources = new List<ItemDataSO>();
        [SerializeField] private Text resourceText;

        public void Refresh()
        {
            if (resourceText == null)
            {
                return;
            }

            if (InventorySystem.Instance == null)
            {
                resourceText.text = "Inventory unavailable.";
                return;
            }

            resourceText.text = string.Empty;
            foreach (ItemDataSO item in trackedResources)
            {
                int amount = InventorySystem.Instance.GetResourceAmount(item);
                resourceText.text += $"{item.displayName}: {amount}\n";
            }
        }
    }
}
