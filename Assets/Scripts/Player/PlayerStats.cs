using UnityEngine;

// [CreateAssetMenu]
public class PlayerStats : ScriptableObject
{
    public float MaxHP = 10.0f;

    [Header("Move")]
    public float MoveSpeed = 5.0f;
    public float Acceleration = 5.0f;

    [Header("Dash")]
    public float DashSpeed = 5.0f;
    public float DashDuration = 0.82f;


}