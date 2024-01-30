using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private InventoryUI inventoryUI;
    public List<string> _itemInventory { get; private set; }
    public List<Sprite> _spriteInventory { get; private set; }

    private void Start()
    {
        _itemInventory = new List<string>();
        _spriteInventory = new List<Sprite>();
    }
    public void Add(PickableItem item)
    {
        _itemInventory.Add(item.name);
        _spriteInventory.Add(item.UI_image);
        inventoryUI.updateUI = true;
    }
    
    public void Remove(PickableItem item)
    {
        if(Has(item))
        {
            _itemInventory.Remove(item.name);
            _spriteInventory.Remove(item.UI_image);
            inventoryUI.updateUI = true;
        }

    }

    public bool Has(PickableItem item)
    {
        return _itemInventory.Contains(item.name);
    }
}