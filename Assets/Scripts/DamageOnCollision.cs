using Game;
using Dreamteck.Forever;
using TMPro;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(PlayerController.TagPlayer))
        {



             var player = collision.collider.GetComponent<PlayerController>();
             Debug.Log($"Collision with {collision.collider.gameObject.tag} detected.");
        }
        Debug.Log(collision.gameObject.name+"name"+ collision.gameObject.tag+ "tag");
    }
    

}
