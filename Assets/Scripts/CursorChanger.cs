using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Changes the cursor icon.
/// </summary>
public class CursorChanger : MonoBehaviour
{
    private Vector2 _hotSpot = Vector2.zero;


    private void OnEnable()
    {
        InteractionStateMachine.InteractionStateChanged += OnHandStateChanged;
    }

    private void OnDisable()
    {
        InteractionStateMachine.InteractionStateChanged -= OnHandStateChanged;
    }

    private void OnHandStateChanged(IInteractionState state)
    {
        Texture2D newCursor = state.stateCursor;
        SetCursor(newCursor);
    }

    private void SetCursor(Texture2D cursor)
    {
        if (cursor != null)
        {
            Cursor.SetCursor(cursor, _hotSpot, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(null, _hotSpot, CursorMode.Auto);
        }
    }
}
