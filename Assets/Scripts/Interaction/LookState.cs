using System;
using UnityEngine;

[Serializable]
public class LookState : IInteractionState
{
    public Texture2D stateCursor { get; set; }

    public LookState(Texture2D cursor)
    {
        stateCursor = cursor;
    }

    public void InteractLeftClick(Item item)
    {
        item.LookItem();
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
