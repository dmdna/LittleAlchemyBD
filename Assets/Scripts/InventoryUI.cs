using UnityEngine;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public GameObject elementPrefab; 
    public Transform inventoryPanel; 

    private HashSet<string> unlockedElements = new HashSet<string>();

    public void AddElement(string id)
    {
        if (unlockedElements.Contains(id))
        {
            return;
        }

        if (Registry.Instance.elements.TryGetValue(id, out Element element))
        {
            GameObject newElem = Instantiate(elementPrefab, inventoryPanel);
            ElementUI ui = newElem.GetComponent<ElementUI>();
            ui.Setup(id, element.icon);

            unlockedElements.Add(id);
        }
    }
}
