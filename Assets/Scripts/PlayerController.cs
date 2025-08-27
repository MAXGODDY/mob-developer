using Controllers.Input;
using Dreamteck.Forever;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;


namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        private InputController _inputController;
        [SerializeField] public Runner _basicRunner;
        [SerializeField] private float _slideSpeed = 5f;
        [SerializeField] private float _joystickSlow = 2f;
        [SerializeField] Animator _animator;
        [SerializeField] private GameObject _lobiCanvas;
        [SerializeField] private float _hp = 1f;
        [SerializeField] public GameObject _player;


        public const string PlayerTag = "Player";
        private const string DeathTrigger = "IsDeath";

        private const string RunningBool = "IsRunning";
        private const string JumpingTrigger = "IsJumping";
        private const string idelBool = "idel";

        private Vector2 _targetVector;

        private float _addValue;
        private const int LevelWidth = 5;
        public float _playerpositionZ = 20;

        public void HandleDeath()
        {
            _animator.SetTrigger(DeathTrigger);
            _hp--;
            _basicRunner.followSpeed = 0;
        }

        public void SwitchAnimation()
        {
            if (_basicRunner.followSpeed == _playerpositionZ)
            {
                _animator.SetBool(RunningBool, true);
                _animator.SetBool(idelBool, false);
            }
            else
            {
                _animator.SetBool(RunningBool, false);
                _animator.SetBool(idelBool, true);
            }
        }


        private void Awake()
        {
            _inputController = new();
            _inputController.SubscribeEvents();
            _animator.SetBool(RunningBool, true);
            SubsribeEvents();
        }



        private void SubsribeEvents()
        {
            _inputController.MovementRecieved += OnMovementRecieved;
            _inputController.MovementEnd += OnMovementEndd;
            _inputController.JumpStarted += OnJumpPressed;
            _inputController.Started += OnStarted;
            _inputController.Setings += OnSetings;
        }

        private void UnsudscribeEvents()
        {
            _inputController.MovementRecieved -= OnMovementRecieved;
            _inputController.MovementEnd -= OnMovementEndd;
            _inputController.JumpStarted -= OnJumpPressed;
            _inputController.Started -= OnStarted;
            _inputController.Setings -= OnSetings;
        }
        private void OnSetings()
        {
            bool isActive = _lobiCanvas.activeSelf;

            if (isActive)
            {
                StartLobiControler startLobiControler = _lobiCanvas.GetComponent<StartLobiControler>();
                startLobiControler.OpenSetings();
            }
            else
            {
                StartLobiControler startLobiControler = _lobiCanvas.GetComponent<StartLobiControler>();
                startLobiControler.CloseSetings();
            }


        }

        private void OnStarted()
        {
            StartLobiControler script = _lobiCanvas.GetComponent<StartLobiControler>();
            script.StartGame();
        }

        private void OnJumpPressed()
        {
            _animator.SetTrigger(JumpingTrigger);
        }

        private void OnMovementRecieved(Vector2 movement)
        {
            Debug.Log($"Player movement received: {movement}");
            _addValue = movement.x / _joystickSlow;
            _targetVector = new Vector2(Mathf.Clamp(_targetVector.x + _addValue, -LevelWidth, LevelWidth), 0);
        }

        private void OnMovementEndd()
        {
            _targetVector = _basicRunner.motion.offset;
            _addValue = 0;
        }

        private void Update()
        {
            _targetVector = new Vector2(Mathf.Clamp(_targetVector.x + _addValue, -LevelWidth, LevelWidth), 0.4f);
            var finaloffset = Vector2.MoveTowards(_basicRunner.motion.offset, _targetVector, _slideSpeed * Time.deltaTime);
            _basicRunner.motion.offset = finaloffset;
        }


        private void OnDestroy()
        {
            UnsudscribeEvents();
            _inputController.Dispose();

        }
    }
}