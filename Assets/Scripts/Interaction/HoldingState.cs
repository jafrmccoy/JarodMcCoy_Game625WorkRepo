using System;
using UnityEngine;

[Serializable]
public class HoldingState : IInteractionState
{
    public Texture2D stateCursor { get; set; }

    public HoldingState(Texture2D cursor)
    {
        stateCursor = cursor;
    }

    public void InteractLeftClick(Item item)
    {
        item.UseItemOn(PlayerHand.Instance.CurrentHeldItem);
    }

    public void InteractRightClick(Item item)
    {

    }

    public void OnEnterInteractState()
    {

    }

    public void OnExitInteractState()
    {

    }
}