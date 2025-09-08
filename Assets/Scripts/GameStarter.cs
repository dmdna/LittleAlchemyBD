using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public InventoryUI inventory;

    void Start()
    {
        Invoke("StartGame", Time.deltaTime*2);
    }

    void StartGame()
    {
        inventory.AddElement("fire");
        inventory.AddElement("water");
        inventory.AddElement("earth");
        inventory.AddElement("air");
    }
}