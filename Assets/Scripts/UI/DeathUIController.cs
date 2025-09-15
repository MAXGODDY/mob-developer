using Dreamteck.Forever;
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
    [SerializeField] private LoadingScreenController _loadingScreenController;

    private PlayerController _playerController;
    private StartLobiControler _startLobiControler;

    [Inject]
    public void Construct(PlayerController playerController, StartLobiControler startLobiControler)
    {
        _playerController = playerController;
        _startLobiControler = startLobiControler;
    }

    private void Start()
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
        var tree = TreeMemory.LastDeadlyTree;
        if (tree != null)
        {
            tree.DisableTree();
        }
        _deathCanvas.SetActive(false);
        _loadingScreenController._canvas.SetActive(true);
        LevelGenerator.instance.Restart();
        _playerController._targetVector = new Vector2(0f, 0.4f);
        _playerController._basicRunner.motion.offset = _playerController._targetVector;
        _loadingScreenController.RestartGame();
    }


    private void ContinueGame()
    {
        var tree = TreeMemory.LastDeadlyTree;
        if (tree != null)
        {
            tree.DisableTree();
        }
        _deathCanvas.SetActive(false);
        _playerController._isDeath = false;
        _playerController.SwitchAnimationDeat();
        _playerController.StartRunning();
        _playerController.SwitchInput(InputMode.Gameplay);
        _startLobiControler._mainCanvas.SetActive(true);
    }

    private void ReturnToMenu()
    {
        var tree = TreeMemory.LastDeadlyTree;
        if (tree != null)
        {
            tree.DisableTree();
        }
        _deathCanvas.SetActive(false);
        _loadingScreenController._canvas.SetActive(true);
        LevelGenerator.instance.Restart();
        _playerController._targetVector = new Vector2(0f, 0.4f);
        _playerController._basicRunner.motion.offset = _playerController._targetVector;
        _loadingScreenController.StartGameWithLoading();
    }

}
