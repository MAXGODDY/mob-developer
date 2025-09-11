using Game;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VContainer;

public class DeathUIController : MonoBehaviour
{
    [SerializeField] private GameObject _deathCanvas;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _menuButton;

    private PlayerController _playerController;

    [Inject]
    public void Construct(PlayerController playerController)
    {
        _playerController = playerController;
    }

    private void Awake()
    {
        _deathCanvas.SetActive(false);

        _restartButton.onClick.AddListener(RestartGame);
        _continueButton.onClick.AddListener(ContinueGame);
        _menuButton.onClick.AddListener(ReturnToMenu);
    }

    public void ShowDeathUI()
    {
        _deathCanvas.SetActive(true);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ContinueGame()
    {
        _deathCanvas.SetActive(false);
        _playerController.StartRunning();
    }

    private void ReturnToMenu()
    {
        _deathCanvas.SetActive(false);
        _playerController.SwitchInput(PlayerController.InputMode.Menu);
    }
}
