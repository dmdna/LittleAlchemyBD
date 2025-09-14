using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ElementUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text label;

    private string elementId;

    public string GetElementId() => elementId;

    public void Setup(string id, Sprite sprite)
    {
        elementId = id;
        icon.sprite = sprite;
        label.text = id;
    }


    public void HoverSFX()
    {
        SFXManager.Instance.PlayHover();
    }
}