using Game;
using Dreamteck.Forever;
using TMPro;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    private const string DamageOnCollisionTag = "Trees";
    


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == DamageOnCollisionTag)
        {
            collision.collider.GetComponentInParent<PlayerController>()?.HandleDeath();
            Debug.Log($"Collision with {collision.collider.gameObject.tag} detected.");

        }

    }
    

}
