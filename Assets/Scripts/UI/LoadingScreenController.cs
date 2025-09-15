using Controllers.Input;
using Dreamteck.Forever;
using Game;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.XInput;
using VContainer;

public class LoadingScreenController : MonoBehaviour
{
    [SerializeField] public GameObject _canvas;
    [SerializeField] private CanvasGroup _loadingScreen;
    [Header("Coroutione")]
    [SerializeField] private float _fadeOutDuration = 1f;
    [Range(0f, 1f)]
    [SerializeField] private float _targetAlpha = 0f;
    [SerializeField] private GameObject _lobiCanvas;




    public float _playerpositionZ = 20;

    private PlayerController _playerController;
    private StartLobiControler _startLobiControler;
    [Inject]
    public void Construct(PlayerController playerController, StartLobiControler startLobiControler)
    {
        _playerController = playerController;
        _startLobiControler = startLobiControler;
    }

    private void Update()
    {
        if (_playerController._player.transform.position.z == _playerpositionZ)
        {
            _playerController._basicRunner.followSpeed = 0;
        }
    }

    private void Start()
    {
        StartCoroutine(FadeOut(_fadeOutDuration, _targetAlpha, _loadingScreen));
    }


    private IEnumerator FadeOut(float duration, float targetAlpha, CanvasGroup loading)
    { 
        yield return new WaitForSeconds(9);

        float currentTime = 0f;
        float startAlpha = loading.alpha;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, currentTime / duration);
            loading.alpha = alpha;
            yield return null;
        }
        
        _canvas.SetActive(false);
        _lobiCanvas.SetActive(true);
    }
    public void StartGameWithLoading()
    {
        _loadingScreen.alpha = _fadeOutDuration;
        _playerController.SwitchAnimationDeatOnIdel(true);
        _startLobiControler.SwitchCamera();
        
        StartCoroutine(FadeOut(_fadeOutDuration, _targetAlpha, _loadingScreen));
    }
    public void RestartGame()
    {
        _loadingScreen.alpha = _fadeOutDuration;
        _playerController.SwitchAnimationDeat(false);
        StartCoroutine(FadeOut2(_fadeOutDuration, _targetAlpha, _loadingScreen));
    }
    private IEnumerator FadeOut2(float duration, float targetAlpha, CanvasGroup loading)
    {
        yield return new WaitForSeconds(10);

        float currentTime = 0f;
        float startAlpha = loading.alpha;


        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, currentTime / duration);
            loading.alpha = alpha;
            yield return null;

        }
        _canvas.SetActive(false);
        _startLobiControler._mainCanvas.SetActive(true);
        _playerController.StartRunning();
        _playerController.SwitchInput(InputMode.Gameplay);
        
    }
}
