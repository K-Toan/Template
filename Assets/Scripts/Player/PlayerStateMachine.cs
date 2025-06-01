using Template.Interfaces;
using UnityEngine;

namespace Template.Characters.Player
{
    public class PlayerStateMachine : MonoBehaviour, IStateMachine<PlayerBaseState>
    {
        [Header("Settings")]
        public bool HasAnimator;

        [Header("Components")]
        public Rigidbody2D Rb;
        public Animator Animator;
        public SpriteRenderer SpriteRenderer;

        [Header("Scritps")]
        public PlayerStatsSystem Stats;
        public PlayerInputSystem Input;

        [Header("State")]
        private PlayerStateFactory _stateFactory;
        private PlayerBaseState _currentState;

        public void Awake()
        {
            // Initialize components
            Rb = GetComponent<Rigidbody2D>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
            HasAnimator = TryGetComponent<Animator>(out Animator);

            Stats = GetComponent<PlayerStatsSystem>();
            Input = GetComponent<PlayerInputSystem>();

            // Initialize state
            _stateFactory = new PlayerStateFactory(this);
            _currentState = _stateFactory.Default();
        }

        public void Start()
        {
            // Enter default state
            SwitchState(_currentState);
        }

        private void Update()
        {
            _currentState.CheckSwitchState();

            _currentState.LogicUpdate();
            _currentState.AnimationUpdate();
            
            HandleFlipX();
        }

        private void FixedUpdate()
        {
            _currentState.PhysicUpdate();
        }

        public void SwitchState(PlayerBaseState newState)
        {
            if (_currentState == null)
            {
                Logger.LogError("Current state is null. Cannot exit current state.");
                return;
            }

            if (newState == null)
            {
                Logger.LogError("New state is null. Cannot switch to null state.");
                return;
            }

            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

        private void HandleFlipX()
        {
            if (Rb.linearVelocityX < 0)
            {
                SpriteRenderer.flipX = true;
            }
            else if (Rb.linearVelocityX > 0)
            {
                SpriteRenderer.flipX = false;
            }
        }
    }
}