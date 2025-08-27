using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private TMP_Text _playScoreText;

    private int sessionScore;
    private PlayerData _playerData;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        _playerData = GameSaver.Load();
        sessionScore = 0;
        UpdateUI();
    }

    public void AddScore(int value)
    {
        sessionScore += value;
        _playerData.TotalScore += value;
        GameSaver.Save(_playerData);
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (_playScoreText != null)
            _playScoreText.text = sessionScore.ToString();
    }

    public int GetSessionScore() => sessionScore;
    public int GetTotalScore() => _playerData.TotalScore;
}
