using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PlayfieldElement : MonoBehaviour, IDropHandler
{
    public Image icon;
    public TMP_Text label;
    private string elementId;

    public void Setup(string id, Sprite sprite)
    {
        elementId = id;
        icon.sprite = sprite;
        label.text = id;
    }

    public string GetElementId()
    {
        return elementId;
    }

    public void OnDrop(PointerEventData eventData)
    {
        // Case 1: PlayfieldElement dropped
        PlayfieldElement droppedPF = eventData.pointerDrag.GetComponent<PlayfieldElement>();
        if (droppedPF != null && droppedPF != this)
        {
            TryCombine(droppedPF.GetElementId(), droppedPF.gameObject);
            return;
        }

        // Case 2: Inventory ElementUI dropped
        ElementUI droppedInv = eventData.pointerDrag.GetComponent<ElementUI>();
        if (droppedInv != null)
        {
            TryCombine(droppedInv.GetElementId(), null); // no gameobject to destroy
        }
    }

    private void TryCombine(string otherId, GameObject otherGO)
    {
        string resultId = Registry.Instance.TryCombine(elementId, otherId);

        if (resultId != null)
        {
            Element result = Registry.Instance.elements[resultId];

            // spawn new combined element
            Vector3 spawnPos = (otherGO != null)
                ? (transform.position + otherGO.transform.position) / 2f
                : transform.position; // if inventory, spawn on this

            GameObject newElem = Instantiate(gameObject, transform.parent);
            newElem.transform.position = spawnPos;

            PlayfieldElement pf = newElem.GetComponent<PlayfieldElement>();
            pf.Setup(resultId, result.icon);

            // destroy old playfield objects
            if (otherGO != null) Destroy(otherGO);
            Destroy(gameObject);

            // add to inventory
            FindObjectOfType<InventoryUI>().AddElement(resultId);
        }
    }
}