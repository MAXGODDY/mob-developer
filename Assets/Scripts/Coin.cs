using Game;
using JSAM;
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
            AudioManager.PlaySound(LesonAudioSounds.HitSFX);

            ScoreManager.Instance.AddScore(1);

            Destroy(gameObject);
            
        }
    }
}
