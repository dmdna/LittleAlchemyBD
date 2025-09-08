using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject elementPrefab;
    public Transform inventoryPanel;

    public void AddElement(string id)
    {
        if (Registry.Instance.elements.TryGetValue(id, out Element element))
        {
            Debug.Log("adding element " + id);
            GameObject newElem = Instantiate(elementPrefab, inventoryPanel);
            ElementUI ui = newElem.GetComponent<ElementUI>();
            ui.Setup(id, element.icon);
        }
    }
}