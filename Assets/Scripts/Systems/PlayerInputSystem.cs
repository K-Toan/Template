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
    public void OnPrimaryFire(InputValue value) => PrimaryFire = value.isPressed;
    public void OnSecondaryFire(InputValue value) => SecondaryFire = value.isPressed;
    public void OnDash(InputValue value) => Dash = value.isPressed;
    public void OnDodge(InputValue value) => Dodge = value.isPressed;
}
