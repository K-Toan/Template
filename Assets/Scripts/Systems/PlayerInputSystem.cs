using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystem : MonoBehaviour
{
    [Header("Inputs")]
    public bool PrimaryFire;
    public bool SecondaryFire;
    public bool Dash;
    public bool Dodge;
    public Vector2 Move;
    public Vector2 MousePosition;

    public void OnMove(InputValue value) => Move = value.Get<Vector2>();
    // public Vector2 OnCameraMousePosition() => Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

    public void OnPrimaryFire(InputValue value) => PrimaryFire = HandleButton(value, nameof(OnPrimaryFire));
    public void OnSecondaryFire(InputValue value) => SecondaryFire = HandleButton(value, nameof(OnSecondaryFire));
    public void OnDash(InputValue value) => Dash = HandleButton(value, nameof(OnDash));
    public void OnDodge(InputValue value) => Dodge = HandleButton(value, nameof(OnDodge));

    private bool HandleButton(InputValue value, string name)
    {
        #if DEBUG
            Debug.Log($"{name}: {value.isPressed}");
        #endif
        
        return value.isPressed;
    }
}
