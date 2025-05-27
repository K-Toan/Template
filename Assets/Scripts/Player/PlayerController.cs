using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    public float DashSpeed = 12.0f;
    public float DashDuration = 0.22f;
    public float DashCooldownDuration = 1.0f;
    public Vector2 DashDir;

    [Header("???")]
    public PlayerInputSystem Input;
    public PlayerStateMachine StateMachine;
    public PlayerAnimationSystem AnimSystem;

    [Header("Components")]
    public Rigidbody2D Rb;
    public Animator Anim;
    public SpriteRenderer SprtRenderer;

    // private PlayerAnimationSystem _anim;
    // private PlayerCombatSystem _combat;
    // private PlayerInventorySystem _inventory;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        SprtRenderer = GetComponent<SpriteRenderer>();

        Input = GetComponent<PlayerInputSystem>();
        StateMachine = gameObject.AddComponent<PlayerStateMachine>();
        AnimSystem = gameObject.AddComponent<PlayerAnimationSystem>();
    }

    private void Start()
    {
        StateMachine.Initialize(this);
        AnimSystem.Initialize(this);
    }

    private void Update()
    {
        MoveDir = Input.Move.normalized;

        if (MoveDir != Vector2.zero)
        {
            LastMoveDir = MoveDir;
        }

        CurrentSpeed = Rb.linearVelocity.magnitude / MoveSpeed;

        StateMachine?.Update();
        AnimSystem?.Update();
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