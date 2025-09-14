using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public InventoryUI inventory;

    void Start()
    {
        // Small delay before initializing the game
        Invoke(nameof(StartGame), Time.deltaTime * 2);
    }

    void StartGame()
    {
        // Add base ingredients at the start
        inventory.AddElement("beans");
        inventory.AddElement("rice");
        inventory.AddElement("tomato");
        inventory.AddElement("onion");
        inventory.AddElement("meat");
        inventory.AddElement("avocado");
        inventory.AddElement("water");
        inventory.AddElement("wheat");
        inventory.AddElement("egg");
        inventory.AddElement("fire");
        inventory.AddElement("milk");
    }
}
