using System;
using UnityEngine;

[Serializable]
public class DefaultState : IInteractionState
{
    public Texture2D stateCursor { get; set; }

    public DefaultState(Texture2D cursor)
    {
        stateCursor = cursor;
    }

    public void InteractLeftClick(Item item)
    {

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
