using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    [SerializeField] InputActionReference _inventoryAction;

    [SerializeField] GameObject _inventoryMenuObject;

    public static event Action InventoryOpened;
    public static event Action InventoryClosed;

    private void Update()
    {
        if (_inventoryAction.action.WasPressedThisFrame())
        {
            _inventoryMenuObject.SetActive(!_inventoryMenuObject.activeInHierarchy);
            if (_inventoryMenuObject.activeInHierarchy) InventoryOpened?.Invoke();
            else InventoryClosed?.Invoke();
        }
    }
}
