using Game;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool collected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (collected) return;

        if (other.GetComponentInParent<PlayerController>() != null)
        {
            collected = true;
            GetComponent<Collider>().enabled = false;

            ScoreManager.Instance.AddScore(1);

            Destroy(gameObject);
        }
    }
}
