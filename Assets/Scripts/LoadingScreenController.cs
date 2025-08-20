using Dreamteck.Forever;
using Game;
using System.Collections;
using UnityEngine;

public class LoadingScreenController : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private CanvasGroup _loadingScreen;
    [Header("Coroutione")]
    [SerializeField] private float _fadeOutDuration = 1f;
    [Range(0f, 1f)]
    [SerializeField] private float _targetAlpha = 0f;
    [SerializeField] private GameObject _lobiCanvas;




    public float _playerpositionZ = 20;

    public PlayerController PlayerController;

    private void Update()
    {
        if (PlayerController._player.transform.position.z == _playerpositionZ)
        {
            PlayerController._basicRunner.followSpeed = 0;
            
            Debug.Log("Player reached the target position, stopping the runner.");
        }
    }

    private void Start()
    {
        StartCoroutine(FadeOut(_fadeOutDuration, _targetAlpha, _loadingScreen));
    }





    private IEnumerator FadeOut(float duration, float targetAlpha, CanvasGroup loading)
    {
        yield return new WaitForSeconds(3);

        float currentTime = 0f;
        float startAlpha = loading.alpha;


        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, currentTime / duration);
            loading.alpha = alpha;
            if (PlayerController._player.transform.position.z > _playerpositionZ)
            {
                PlayerController._basicRunner.followSpeed = 0;
                PlayerController.SwitchAnimation();
            }
            yield return null;

        }
        _canvas.SetActive(false); // отключает объект и все его компоненты
        _lobiCanvas.SetActive(true);

    }
}
