using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private GameObject dragClone;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Create a clone for dragging
        dragClone = Instantiate(gameObject, canvas.transform);
        rectTransform = dragClone.GetComponent<RectTransform>();
        rectTransform.position = eventData.position;

        canvasGroup = dragClone.AddComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = false; // allow drop detection
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragClone != null)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragClone != null)
        {
            Destroy(dragClone); // clone is only temporary, DropZone will spawn the real PlayfieldElement
        }
    }
}
