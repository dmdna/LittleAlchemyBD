using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVLoader : MonoBehaviour
{
    public TextAsset elementsFile;
    public TextAsset recipesFile;

    void Start()
    {
        LoadElements();
        LoadRecipes();
    }

    void LoadElements()
    {
        string[] lines = elementsFile.text.Split('\n');
        for (int i = 1; i < lines.Length; i++)
        { // skip header
            string line = lines[i].Trim();
            if (string.IsNullOrEmpty(line)) continue;

            string[] parts = line.Split(',');
            string id = parts[0];
            string path = parts[1];

            Sprite icon = Resources.Load<Sprite>(path);

            Element e = new Element { id = id, icon = icon };
            Registry.Instance.elements[id] = e;
        }
    }

    void LoadRecipes()
    {
        string[] lines = recipesFile.text.Split('\n');
        for (int i = 1; i < lines.Length; i++)
        { // skip header
            string line = lines[i].Trim();
            if (string.IsNullOrEmpty(line)) continue;

            string[] parts = line.Split(',');
            string inputA = parts[0];
            string inputB = parts[1];
            string output = parts[2];

            Registry.Instance.recipes[(inputA, inputB)] = output;
        }
    }
}