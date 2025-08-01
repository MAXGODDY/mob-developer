using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private Transform[] _points;

    [SerializeField] private byte _minCoins;

    public void Generate(Vector3 position)
    {
        int coinsToGenerate = UnityEngine.Random.Range(_minCoins, _points.Length + 1);

        for (int i = 0; i < coinsToGenerate; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, _points.Length);
            Vector3 spawnPosition = _points[randomIndex].position + position;
            Instantiate(_coin, spawnPosition, Quaternion.identity);
        }

    }
}
