using UnityEngine;

public interface IInteractionState
{
    Texture2D stateCursor { get; set; }
    public abstract void InteractLeftClick(Item item);
    public abstract void InteractRightClick(Item item);
    public abstract void OnEnterInteractState();
    public abstract void OnExitInteractState();
}
