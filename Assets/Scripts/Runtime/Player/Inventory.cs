using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    private readonly HashSet<string> items = new();

    private void Awake()
    {
        if(Instance is null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddItem(string itemName)
    {
        Debug.Log($"Adding item: {itemName}");
        items.Add(itemName);
    }

    public void RemoveItem(string itemName)
        => items.Remove(itemName);
    
    public bool HasItem(string itemName)
        => items.Contains(itemName);

}
