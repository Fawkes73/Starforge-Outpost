using System;
using System.Collections.Generic;
using UnityEngine;
using StarforgeOutpost.Data;

namespace StarforgeOutpost.Inventory
{
    public class InventorySystem : MonoBehaviour
    {
        public static InventorySystem Instance { get; private set; }

        private readonly Dictionary<ItemDataSO, int> resourceInventory = new Dictionary<ItemDataSO, int>();
        private readonly Dictionary<CraftedItemInstance, int> craftedItems = new Dictionary<CraftedItemInstance, int>();

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void AddResource(ItemDataSO item, int amount)
        {
            if (item == null || amount <= 0)
            {
                return;
            }

            resourceInventory.TryGetValue(item, out int currentAmount);
            resourceInventory[item] = currentAmount + amount;
        }

        public bool HasResource(ItemDataSO item, int amount)
        {
            if (item == null)
            {
                return false;
            }

            return resourceInventory.TryGetValue(item, out int currentAmount) && currentAmount >= amount;
        }

        public bool HasResources(List<ResourceAmount> costs)
        {
            foreach (ResourceAmount cost in costs)
            {
                if (!HasResource(cost.item, cost.amount))
                {
                    return false;
                }
            }

            return true;
        }

        public void ConsumeResources(List<ResourceAmount> costs)
        {
            foreach (ResourceAmount cost in costs)
            {
                RemoveResource(cost.item, cost.amount);
            }
        }

        public void RemoveResource(ItemDataSO item, int amount)
        {
            if (item == null || amount <= 0)
            {
                return;
            }

            if (!resourceInventory.TryGetValue(item, out int currentAmount))
            {
                return;
            }

            int newAmount = Mathf.Max(0, currentAmount - amount);
            resourceInventory[item] = newAmount;
        }

        public void AddCraftedItem(CraftedItemInstance craftedItem, int amount)
        {
            if (craftedItem.Item == null || amount <= 0)
            {
                return;
            }

            craftedItems.TryGetValue(craftedItem, out int currentAmount);
            craftedItems[craftedItem] = currentAmount + amount;
        }

        public int GetResourceAmount(ItemDataSO item)
        {
            return resourceInventory.TryGetValue(item, out int currentAmount) ? currentAmount : 0;
        }

        public int GetCraftedItemAmount(CraftedItemInstance craftedItem)
        {
            return craftedItems.TryGetValue(craftedItem, out int currentAmount) ? currentAmount : 0;
        }
    }

    [Serializable]
    public struct CraftedItemInstance : IEquatable<CraftedItemInstance>
    {
        [SerializeField] private ItemDataSO item;
        [SerializeField] private Color color;

        public ItemDataSO Item => item;
        public Color Color => color;

        public CraftedItemInstance(ItemDataSO item, Color color)
        {
            this.item = item;
            this.color = color;
        }

        public bool Equals(CraftedItemInstance other)
        {
            return item == other.item && color.Equals(other.color);
        }

        public override bool Equals(object obj)
        {
            return obj is CraftedItemInstance other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = item != null ? item.GetHashCode() : 0;
                hash = (hash * 397) ^ color.GetHashCode();
                return hash;
            }
        }
    }
}
