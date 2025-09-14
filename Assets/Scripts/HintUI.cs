using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HintUI : MonoBehaviour
{
    [Header("UI References")]
    public GameObject hints;
    public GameObject deliciousTxt;
    public Image inputAIcon;
    public Image inputBIcon;
    public Image outputIcon;

    [Header("Sprites")]
    public Sprite questionMarkSprite;

    [SerializeField]
    private InventoryUI inventory;

    void Start()
    {
        inventory = FindObjectOfType<InventoryUI>();
        inventory.OnElementUnlocked += (_) => RefreshHint();
        ResetHints(); // ensure fresh start
    }

    public void ResetHints()
    {
        hints.SetActive(true);
        deliciousTxt.SetActive(false);

        inputAIcon.sprite = null;
        inputBIcon.sprite = null;
        outputIcon.sprite = null;

        RefreshHint();
    }

    public void RefreshHint()
    {
        var unlocked = inventory.GetUnlockedElements();
        var possible = new List<(string a, string b, string output)>();

        foreach (var recipe in Registry.Instance.recipes)
        {
            string a = recipe.Key.Item1;
            string b = recipe.Key.Item2;
            string output = recipe.Value;

            if (unlocked.Contains(a) && unlocked.Contains(b) && !unlocked.Contains(output))
            {
                possible.Add((a, b, output));
            }
        }

        if (possible.Count > 0)
        {
            var choice = possible[Random.Range(0, possible.Count)];

            inputAIcon.sprite = Registry.Instance.elements[choice.a].icon;
            inputBIcon.sprite = Registry.Instance.elements[choice.b].icon;
            outputIcon.sprite = questionMarkSprite;
        }
        else
        {
            // no more hints
            inputAIcon.sprite = null;
            inputBIcon.sprite = null;
            outputIcon.sprite = null;
        }
    }
}
