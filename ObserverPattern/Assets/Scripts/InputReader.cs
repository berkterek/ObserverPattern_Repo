using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader
{
    public float UpDown { get; private set; }
    public bool IsFire { get; private set; }
    
    public InputReader()
    {
        GameInputActions input = new GameInputActions();

        input.Player.Move.performed += OnMove;
        input.Player.Move.canceled += OnMove;

        input.Player.Fire.performed += OnFire;
        input.Player.Fire.canceled += OnFire;
        
        input.Enable();
    }

    void OnFire(InputAction.CallbackContext context)
    {
        IsFire = context.ReadValueAsButton();
    }

    void OnMove(InputAction.CallbackContext context)
    {
        UpDown = context.ReadValue<Vector2>().y;
    }
}
