using UnityEngine;

namespace StarforgeOutpost.Crafting
{
    public class CraftCustomization : MonoBehaviour
    {
        public void ApplyColor(GameObject itemInstance, Color color)
        {
            if (itemInstance == null)
            {
                return;
            }

            Renderer[] renderers = itemInstance.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in renderers)
            {
                foreach (Material material in renderer.materials)
                {
                    material.color = color;
                }
            }
        }
    }
}
