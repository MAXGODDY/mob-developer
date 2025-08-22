using Game;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private const string CoinTrigger = "CoinTrigger";
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == CoinTrigger)
        {
            SingletonScoreManager._score++;
            SingletonScoreManager._text.text = SingletonScoreManager._score.ToString();
            Destroy(gameObject);
        }
    }
}
