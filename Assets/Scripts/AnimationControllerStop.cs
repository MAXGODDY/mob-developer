using Dreamteck.Forever;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class AnimationControllerStop : MonoBehaviour
{

    [SerializeField] private Runner _playerRunner;
    [SerializeField] Animator _animator;

    private const string IdelBool = "Idel";


    void Update()
    {
        if (_playerRunner.followSpeed == 0)
        {
            _animator.SetTrigger(IdelBool);
        }
    }
}
