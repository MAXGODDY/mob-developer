using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static TMP_Text _text;

    private static int _score;

    private string TagPlayer = "Player";



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagPlayer))
        {
            _score++;
            _text.text = _score.ToString();
            Destroy(gameObject);
        }

    }
}
