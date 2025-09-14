using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private GameObject dragClone;  // the clone being dragged

    void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Create a clone of this UI element for dragging
        SFXManager.Instance.PlayPickup();
        dragClone = Instantiate(gameObject, canvas.transform);
        rectTransform = dragClone.GetComponent<RectTransform>();
        canvasGroup = dragClone.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = dragClone.AddComponent<CanvasGroup>();
        }

        canvasGroup.blocksRaycasts = false; // let drops detect it
        rectTransform.position = eventData.position;
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
            SFXManager.Instance.PlayDrop();
            Destroy(dragClone); // always remove the temporary clone
        }
    }
}
