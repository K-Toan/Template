using System.Collections;
using UnityEngine;

namespace Template.Characters.Player
{
    public class PlayerStatsSystem : MonoBehaviour
    {
        [Header("Static Stats")]
        // HP
        public float MaxHP = 10.0f;
        // Movement
        public float MoveSpeed = 4.0f;
        public float Acceleration = 5.0f;
        public float Deceleration = 10.0f;
        // Dash
        public float DashSpeed = 12.0f;
        public float DashDuration = 0.15f;
        public float DashCooldownDuration = 2.0f;

        [Header("Runtime Stats")]
        // HP
        public float CurrentHP = 10.0f;
        // Movement
        public bool CanMove = true;
        // Dash
        public bool CanDash = true;
        public Vector2 FaceDirection;
        // Attack
        public bool CanAttack = true;

        private void Update()
        {
        }

        public void StartDashCooldown() => StartCoroutine(DashCooldownCoroutine());

        private IEnumerator DashCooldownCoroutine()
        {
            CanDash = false;
            yield return new WaitForSeconds(DashCooldownDuration);
            CanDash = true;
        }
    }
}