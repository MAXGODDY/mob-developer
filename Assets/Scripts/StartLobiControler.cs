using Controllers.Input;
using Dreamteck.Forever;
using Game;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;


public class StartLobiControler : MonoBehaviour
{
    [SerializeField] private GameObject _mainCanvas;
    [SerializeField] private GameObject _lobiCanvas;
    [SerializeField] private GameObject _setingsCanvas;
    [SerializeField] private CinemachineVirtualCameraBase _mainCamera;
    [SerializeField] private CinemachineVirtualCameraBase _lobiCamera;
    [SerializeField] private PlayerController _playerController;



    public void StartGame()
    {
        _playerController.SwitchInput(PlayerController.InputMode.Gameplay);
        _setingsCanvas.SetActive(false);
        _lobiCanvas.SetActive(false);
        _mainCanvas.SetActive(true);

        _mainCamera.Priority = 11;
        _lobiCamera.Priority = 9;

        
        _playerController.StartRunning();
        _playerController.SwitchAnimation();
    }


    public void OpenSetings()
    {
        _setingsCanvas.SetActive(true);
        _lobiCanvas.SetActive(false);
    }

    public void CloseSetings()
    {
        _setingsCanvas.SetActive(false);
        _lobiCanvas.SetActive(true);
    }
}
