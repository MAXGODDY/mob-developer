using Game;
using Dreamteck.Forever;
using TMPro;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    public static Animator _animator;
    [SerializeField] private float _hp = 1f;
    public static Runner _basicRunner;

    private const string DeathTrigger = "IsDeath";
    private const string DamageOnCollisionTag = "Trees";


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == DamageOnCollisionTag && _hp != 0)
        {
            _animator.SetTrigger(DeathTrigger);
            _basicRunner.followSpeed = 0;
            _hp--;
            Debug.Log($"Collision with {collision.collider.gameObject.tag} detected.");

        }

    }
    

}
