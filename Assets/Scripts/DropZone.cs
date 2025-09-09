using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public GameObject playfieldElementPrefab;

    public void OnDrop(PointerEventData eventData)
    {
        ElementUI dropped = eventData.pointerDrag.GetComponent<ElementUI>();
        if (dropped != null)
        {
            string id = dropped.GetElementId();
            Element e = Registry.Instance.elements[id];

            // spawn new playfield element
            GameObject newElem = Instantiate(playfieldElementPrefab, transform);
            newElem.transform.position = eventData.position;

            PlayfieldElement pf = newElem.GetComponent<PlayfieldElement>();
            pf.Setup(id, e.icon);
        }
    }

    public void ClearPlayfield()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}