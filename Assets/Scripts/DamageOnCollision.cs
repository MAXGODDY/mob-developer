using Game;
using UnityEngine;
using VContainer;

public class DamageOnCollision : MonoBehaviour
{
    private DeathUIController _deathUIController;
    [Inject]
    public void Construct(DeathUIController deathUIController)
    {
        _deathUIController = deathUIController;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag(PlayerController.PlayerTag))
        {
            collision.collider.GetComponentInParent<PlayerController>()?.HandleDeath();
            _deathUIController.ShowDeathUI();
        }
    }


}