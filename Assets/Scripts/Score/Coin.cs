using Game;
using JSAM;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool collected = false;
    GameFeedbackManager _gameFeedbackManager;
    private void Start()
    {
        _gameFeedbackManager = FindObjectOfType<GameFeedbackManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (collected) return;

        if (other.GetComponentInParent<PlayerController>() != null)
        {
            collected = true;
            GetComponent<Collider>().enabled = false;

            AudioManager.PlaySound(LesonAudioSounds.HitSFX);
            _gameFeedbackManager.PlayCoinTextFeedbacks();


            ScoreManager.Instance.AddScore(1);
            

            gameObject.SetActive(false);
        }
    }
}
