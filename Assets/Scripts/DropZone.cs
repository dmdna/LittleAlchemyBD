using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        ElementUI dropped = eventData.pointerDrag.GetComponent<ElementUI>();
        if (dropped != null)
        {
            Debug.Log("Dropped element: " + dropped.GetElementId());
            // TODO: handle combining logic here
        }
    }
}