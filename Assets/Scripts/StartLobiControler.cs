using Game;
using UnityEngine;
using Dreamteck.Forever;
using Unity.Cinemachine;


public class StartLobiControler : MonoBehaviour
{

    [SerializeField] private GameObject _mainCanvas;
    [SerializeField] private GameObject _lobiCanvas;
    [SerializeField] private GameObject _player;
    [SerializeField] private Runner _runner;
    [SerializeField] private Animator _animator;
    [SerializeField] private CinemachineVirtualCameraBase _mainCamera;
    [SerializeField] private CinemachineVirtualCameraBase _lobiCamera;

    private const string IdelBool = "Idel";
    private const string RunningBool = "IsRunning";



    public void StartGame()
    {
        _lobiCanvas.SetActive(false);
        _mainCanvas.SetActive(true);
        _animator.SetBool(IdelBool, false);
        _animator.SetBool(RunningBool, true);
        _mainCamera.Priority = 11;
        _lobiCamera.Priority = 9;
        _runner.followSpeed = 20f;


        MonoBehaviour script = _player.GetComponent(typeof(PlayerController)) as MonoBehaviour;
        script.enabled = true;
    }
}
