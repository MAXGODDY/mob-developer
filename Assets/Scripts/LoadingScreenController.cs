using Dreamteck.Forever;
using Game;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class LoadingScreenController : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private CanvasGroup _loadingScreen;
    [SerializeField] private GameObject _player;
    [SerializeField] private Runner _runner;
    [Header("Coroutione")]
    [SerializeField] private float _fadeOutDuration = 1f;
    [Range(0f, 1f)]
    [SerializeField] private float _targetAlpha = 0f;
    [SerializeField] Animator _animator;

    private const string IdelBool = "Idel";
    private const string RunningBool = "IsRunning";

    float _playerpositionZ = 20;

    private void Start()
    {
        StartCoroutine(FadeOut(_fadeOutDuration, _targetAlpha, _loadingScreen));
        
}

    private void Update()
    {
        if (_player.transform.position.z > 20)
        {
            _runner.followSpeed = 0;
        }
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
            yield return null;
            _canvas.SetActive(false); // отключает объект и все его компоненты
            MonoBehaviour script = _player.GetComponent(typeof(PlayerController)) as MonoBehaviour;
            script.enabled = false;
            _animator.SetBool(RunningBool, false);
            _animator.SetTrigger(IdelBool);
            _canvas.SetActive(false); // отключает объект и все его компоненты



        }
    }


}
