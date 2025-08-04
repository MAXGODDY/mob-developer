using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private Transform[] _points;

    [SerializeField] private byte _minCoins;

    private void Start()
    {
        Generate();
    }



    public void Generate()
    {
        int coinsToGenerate = UnityEngine.Random.Range((int)_minCoins, _points.Length + 1);


        for (int i = 0; i < coinsToGenerate; i++)
        {
            Instantiate(_coin, _points[i]);
        }

    }
}
