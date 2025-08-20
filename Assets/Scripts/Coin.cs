using Game;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Coin collided with: {other.gameObject.tag} {PlayerController.PlayerTag}");
        if (other.gameObject.CompareTag(PlayerController.PlayerTag))
        {
            SingletonScoreManager._score++;
            SingletonScoreManager._text.text = SingletonScoreManager._score.ToString();
            Destroy(gameObject);
            Debug.Log($"Coin collected! New score: {SingletonScoreManager._score}");
        }
    }
}
