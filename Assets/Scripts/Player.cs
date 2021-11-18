using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Habitant
{
    
    public void OnAction(InputAction.CallbackContext context) {
        if (!context.performed) return;
        Attack();
    }

    public void OnInteract(InputAction.CallbackContext context) {
        if (!context.performed) return;
        Debug.Log("INTERACT");
        Debug.Log(context);
    }

    public void OnMove(InputAction.CallbackContext context) {
        moveVec = context.ReadValue<Vector2>();
    }
}
