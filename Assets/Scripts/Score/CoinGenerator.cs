using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private int _minCoins = 3;

    private void Start()
    {
        Generate();
    }

    public void Generate()
    {
        int coinsToGenerate = Random.Range(_minCoins, _spawnPoints.Length + 1);

        for (int i = 0; i < coinsToGenerate; i++)
        {
            Instantiate(_coinPrefab, _spawnPoints[i]);
        }

    }
}
