using Game;
using UnityEngine;
using Dreamteck.Forever;
using Unity.Cinemachine;


public class StartLobiControler : MonoBehaviour
{

    [SerializeField] private GameObject _mainCanvas;
    [SerializeField] private GameObject _lobiCanvas;
    [SerializeField] private CinemachineVirtualCameraBase _mainCamera;
    [SerializeField] private CinemachineVirtualCameraBase _lobiCamera;
    [SerializeField] private PlayerController _playerController;


    private const string IdelBool = "idel";
    private const string RunningBool = "IsRunning";



    public void StartGame()
    {
        _lobiCanvas.SetActive(false);
        _mainCanvas.SetActive(true);
        _mainCamera.Priority = 11;
        _lobiCamera.Priority = 9;
        _playerController._basicRunner.followSpeed = 20f;
        _playerController.SwitchAnimation();

    }
}
