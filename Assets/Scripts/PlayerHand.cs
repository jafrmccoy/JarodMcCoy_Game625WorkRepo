using System;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    [SerializeField] private Item _currentHeldItem;

    public static PlayerHand Instance;
    public Item CurrentHeldItem { get { return _currentHeldItem; } }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    /// <summary>
    /// Gets the item currently in the player's hand.
    /// </summary>
    /// <returns>The Item in the player's hand, if any.</returns>
    public Item GetItemInHand()
    {
        return _currentHeldItem;
    }

    /// <summary>
    /// Puts the given item into the player's hand.
    /// </summary>
    /// <param name="item">The item to be placed in the player's hand.</param>
    public bool PutItemInHand(Item item)
    {
        if (_currentHeldItem != null)
        {
            Debug.Log("Already holding " + _currentHeldItem.Name);
            return false;
        }
        else
        {
            _currentHeldItem = item;
            return true;
        }
    }

    /// <summary>
    /// Removes the current item in the player's hand, and sets it to null.
    /// </summary>
    public bool RemoveItemInHand()
    {
        if (_currentHeldItem != null)
        {
            _currentHeldItem = null;
            return true;
        }
        else
        {
            Debug.Log("Not holding anything.");
            return false;
        }
    }
}
