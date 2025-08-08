using Game;
using TMPro;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    public static Animator _animator;

    private const string PlayerTag = "Player";
    private const string DeathTrigger = "IsDeath";
    private const string DamageOnCollisionTag = "Trees";


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(PlayerTag))
        {
            _animator.SetTrigger(DeathTrigger);
            
        }
        Debug.Log($"Collision with {collision.collider.gameObject.tag} detected.");
    }


}
