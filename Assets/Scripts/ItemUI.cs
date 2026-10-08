using System;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemUI : MonoBehaviour
{
    private Item _itemInSlot;

    public static event Action ItemPlacedInSlot;
    public static event Action ItemTakenFromSlot;

    public void InteractItemUI()
    {
        bool holdingItem = PlayerHand.Instance.GetItemInHand();
        if (holdingItem && _itemInSlot == null)
        {
            Item item = PlayerHand.Instance.GetItemInHand();
            PlayerHand.Instance.RemoveItemInHand();

            _itemInSlot = item;

            _itemInSlot.HideGameObject();

            Transform child = transform.GetChild(0);

            Image slotImage = child.GetComponent<Image>();
            slotImage.sprite = _itemInSlot.Sprite;
            slotImage.enabled = true;
            InteractionStateMachine.Instance.ChangeToState(InteractionStateMachine.Instance.grabState);
            ItemPlacedInSlot?.Invoke();
        }
        else if (_itemInSlot != null)
        {
            InteractionStateMachine.Instance.CurrentInteractionState.InteractLeftClick(_itemInSlot);
            if (PlayerHand.Instance.CurrentHeldItem == _itemInSlot)
            {
                Transform child = transform.GetChild(0);
                Image slotImage = child.GetComponent<Image>();
                slotImage.enabled = false;
                slotImage.sprite = null;
                _itemInSlot = null;
                ItemTakenFromSlot?.Invoke();
            }
        }
    }

    public void TryUseItem()
    {
        if (_itemInSlot != null)
        {
            _itemInSlot.PickupItem();
        }
    }
}
