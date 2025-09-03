using Game;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag(PlayerController.PlayerTag))
        {
            collision.collider.GetComponentInParent<PlayerController>()?.HandleDeath();
        }
    }


}