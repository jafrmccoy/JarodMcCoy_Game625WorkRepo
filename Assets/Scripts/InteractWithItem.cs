using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InteractWithItem : MonoBehaviour
{
    private Camera _mainCamera;
    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) return;

        Vector2 mousePosition = Mouse.current.position.ReadValue();

        Ray ray = _mainCamera.ScreenPointToRay(mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity) && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Item item = hitInfo.collider.gameObject.GetComponent<Item>();
            if (item != null)
            {
                InteractionStateMachine.Instance.CurrentInteractionState.InteractLeftClick(item);
            }
        }
    }
}
