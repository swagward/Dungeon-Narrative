using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private readonly HashSet<string> _items = new();

    public void AddItem(string itemName) => _items.Add(itemName);

    public bool HasItem(string itemName) => _items.Contains(itemName);

    public void RemoveItem(string itemName) => _items.Remove(itemName);
}