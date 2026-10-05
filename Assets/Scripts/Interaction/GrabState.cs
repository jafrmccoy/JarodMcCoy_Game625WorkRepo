using System;
using UnityEngine;

[Serializable]
public class GrabState : IInteractionState
{
    public Texture2D stateCursor { get; set; }

    public GrabState(Texture2D cursor)
    {
        stateCursor = cursor;
    }

    public void InteractLeftClick(Item item)
    {
        item.PickupItem();
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