using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HeldItemGhostSprite : MonoBehaviour
{
    [SerializeField] private Image image;

    private void OnEnable()
    {
        MenuManager.InventoryOpened += OnInventoryOpened;
        MenuManager.InventoryClosed += OnInventoryClosed;
        ItemUI.ItemPlacedInSlot += OnItemPlacedInSlot;
        ItemUI.ItemTakenFromSlot += OnItemTakenFromSlot;
    }

    private void OnDisable()
    {
        MenuManager.InventoryOpened -= OnInventoryOpened;
        MenuManager.InventoryClosed -= OnInventoryClosed;
        ItemUI.ItemPlacedInSlot -= OnItemPlacedInSlot;
        ItemUI.ItemTakenFromSlot -= OnItemTakenFromSlot;
    }

    private void Start()
    {
        image = GetComponent<Image>();
        image.enabled = false;
    }

    private void Update()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        transform.position = mousePosition;
    }

    private void OnInventoryOpened()
    {
        if (PlayerHand.Instance.CurrentHeldItem != null)
        {
            Item item = PlayerHand.Instance.CurrentHeldItem;
            image.sprite = item.Sprite;

            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.25f);
            image.enabled = true;
        }
    }

    private void OnInventoryClosed()
    {
        image.enabled = false;
        image.sprite = null;
    }

    private void OnItemPlacedInSlot()
    {
        image.enabled = false;
        image.sprite = null;
    }

    private void OnItemTakenFromSlot()
    {
        if (PlayerHand.Instance.CurrentHeldItem != null)
        {
            Item item = PlayerHand.Instance.CurrentHeldItem;
            image.sprite = item.Sprite;

            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.25f);
            image.enabled = true;
        }
    }
}
