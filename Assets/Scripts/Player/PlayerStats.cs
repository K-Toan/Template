using UnityEngine;

namespace Template.Characters.Player
{
    public class PlayerStats : MonoBehaviour
    {
        [Header("Base Stats")]
        // HP
        public float MaxHP = 10.0f;
        // Movement
        public float MoveSpeed = 4.0f;
        public float Acceleration = 4.0f;
        public float Deceleration = 10.0f;
        // Dash
        public float DashSpeed = 12.0f;
        public float DashDuration = 0.12f;
        public float DashCooldownDuration = 2.0f;

        [Header("Runtime Stats")]
        // HP
        public float CurrentHP = 10.0f;
        // Movement
        public bool CanMove = true;
        // public float CurrentSpeed = 0.0f;
        // Dash
        public bool CanDash = true;
        public float DashCooldownDurationLeft = 0.0f;
        public Vector2 DashDir;
        // Attack
        public bool CanAttack = true;
    }
}