using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour, IDamageable
{
    [Header("Movement")]
    public float MoveSpeed = 4.0f;
    public float CurrentSpeed = 0.0f;
    public float Acceleration = 4.0f;
    public float Deceleration = 6.0f;
    public Vector2 MoveDir;
    public Vector2 LastMoveDir;

    [Header("Dash")]
    public bool CanDash = true;
    public float DashSpeed = 12.0f;
    public float DashDuration = 0.22f;
    public float DashCooldownDuration = 1.0f;
    public Vector2 DashDir;

    [Header("???")]
    public PlayerStateMachine StateMachine;
    public PlayerAnimationSystem AnimSystem;
    public PlayerInputSystem Input;

    [Header("Components")]
    public Rigidbody2D Rb;
    public Animator Anim;

    // private PlayerAnimationSystem _anim;
    // private PlayerCombatSystem _combat;
    // private PlayerInventorySystem _inventory;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();

        Input = GetComponent<PlayerInputSystem>();
        StateMachine = gameObject.AddComponent<PlayerStateMachine>();
        AnimSystem = gameObject.AddComponent<PlayerAnimationSystem>();
    }

    private void Start()
    {
        StateMachine.Initialize(this);
    }

    private void Update()
    {
        MoveDir = Input.Move.normalized;

        if (MoveDir != Vector2.zero)
        {
            LastMoveDir = MoveDir;
        }

        CurrentSpeed = Vector2.SqrMagnitude(Rb.linearVelocity);

        StateMachine?.Update();
    }

    private void FixedUpdate()
    {
        StateMachine?.FixedUpdate();
    }

    #region State
    public void Move()
    {
        // perform move
        Rb.linearVelocity = Vector2.Lerp(Rb.linearVelocity, MoveDir * MoveSpeed, Acceleration * Time.fixedDeltaTime);
    }

    public void StopMoving()
    {
        // perform move
        Rb.linearVelocity = Vector2.Lerp(Rb.linearVelocity, Vector2.zero, Deceleration * Time.fixedDeltaTime);
    }

    public void Dash()
    {
        // perform dash
        Rb.linearVelocity = DashDir * DashSpeed;
    }
    #endregion

    #region Coroutine
    public void StartDashCooldownCoroutine() => StartCoroutine(DashCooldownCoroutine());
    private IEnumerator DashCooldownCoroutine()
    {
        CanDash = false;
        yield return new WaitForSeconds(DashCooldownDuration);
        CanDash = true;
    }
    #endregion

    #region IDamageble
    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float amount)
    {
        throw new System.NotImplementedException();
    }
    #endregion
}