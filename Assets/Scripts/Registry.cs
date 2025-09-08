using System.Collections.Generic;
using UnityEngine;

public class Element
{
    public string id;
    public Sprite icon;
}

public class Recipe
{
    public string inputA;
    public string inputB;
    public string output;
}

public class Registry : MonoBehaviour
{
    public static Registry Instance;

    public Dictionary<string, Element> elements = new Dictionary<string, Element>();
    public Dictionary<(string, string), string> recipes = new Dictionary<(string, string), string>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public string TryCombine(string a, string b)
    {
        if (recipes.TryGetValue((a, b), out string result)) return result;
        if (recipes.TryGetValue((b, a), out result)) return result;
        return null;
    }
}