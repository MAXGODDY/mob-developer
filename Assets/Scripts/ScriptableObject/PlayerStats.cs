using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    [Header("Runner Movement")]
    [SerializeField] private float initialSpeed = 10f;
    [SerializeField] private float maxSpeed = 30f;
    [SerializeField] private float accelerationRate = 0.5f;

    public float InitialSpeed => initialSpeed;
    public float MaxSpeed => maxSpeed;
    public float AccelerationRate => accelerationRate;
}
