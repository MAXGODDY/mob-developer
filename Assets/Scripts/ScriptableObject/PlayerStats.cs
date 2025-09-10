using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    [Header("Runner Movement")]
    public float initialSpeed = 10f;
    public float maxSpeed = 30f;
    public float accelerationRate = 0.5f;
}
