using UnityEngine;

namespace StarforgeOutpost.Data
{
    [CreateAssetMenu(menuName = "Starforge Outpost/Item Data", fileName = "NewItemData")]
    public class ItemDataSO : ScriptableObject
    {
        public string itemId;
        public string displayName;
        public Sprite icon;
        public GameObject itemPrefab;
        public bool supportsColorCustomization;
        public Color defaultColor = Color.white;
    }
}
