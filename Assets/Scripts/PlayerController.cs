using Controllers.Input;
using Dreamteck.Forever;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using static UnityEditor.Experimental.GraphView.GraphView;


namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        private InputController _inputController;

        [SerializeField] private PlayerStats _playerStats;


        [SerializeField] public Runner _basicRunner;
        [SerializeField] private float _slideSpeed = 5f;
        [SerializeField] private float _joystickSlow = 2f;
        [SerializeField] Animator _animator;
        [SerializeField] private GameObject _lobiCanvas;
        [SerializeField] private float _hp = 1f;
        [SerializeField] public GameObject _player;


        private DeathUIController _deathUIController;
        [Inject]
        public void Construct(DeathUIController deathUIController)
        {
            _deathUIController = deathUIController;
        }



        private float _currentSpeed;
        private float _runTime;
        private bool _isRunning = false;


        public const string PlayerTag = "Player";
        private const string DeathTrigger = "IsDeath";

        private const string RunningBool = "IsRunning";
        private const string JumpingTrigger = "IsJumping";
        private const string idelBool = "idel";

        private Vector2 _targetVector;

        private float _addValue;
        private const int LevelWidth = 5;
        public float _playerpositionZ = 20;
        


        private void Start()
        {
            _currentSpeed = _playerStats.InitialSpeed;
            _basicRunner.followSpeed = 20f;
            _runTime = 0f;
            
        }

        public void HandleDeath()
        {
            SwitchInput(InputMode.Menu);
            _animator.SetTrigger(DeathTrigger);
            _hp--;
            _isRunning = false;
            _currentSpeed = 0f;
            _runTime = 0f;
            _basicRunner.followSpeed = 0f;
            _deathUIController.ShowDeathUI();

            ScoreManager.Instance.SaveScore();
            
            Debug.Log("Player has died.");
        }

        public void SwitchAnimation()
        {
            if (_isRunning)
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
            _inputController = new InputController();
            _animator.SetBool(RunningBool, true);
        }

        private void OnEnable()
        {
            _inputController.SubscribeEvents();
            _inputController.SubsribeEventsSetings();

            _inputController.MovementRecieved += OnMovementRecieved;
            _inputController.MovementEnd += OnMovementEndd;
            _inputController.JumpStarted += OnJumpPressed;
            _inputController.Started += OnStarted;
            _inputController.Setings += OnSetings;
        }

        private void OnDisable()
        {
            _inputController.MovementRecieved -= OnMovementRecieved;
            _inputController.MovementEnd -= OnMovementEndd;
            _inputController.JumpStarted -= OnJumpPressed;
            _inputController.Started -= OnStarted;
            _inputController.Setings -= OnSetings;

            _inputController.Dispose();
            _inputController.DisposeSetings();
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
            if (_isRunning)
            {
                _runTime += Time.deltaTime;

                _currentSpeed = Mathf.Min(
                    _playerStats.InitialSpeed + _playerStats.AccelerationRate * _runTime,
                    _playerStats.MaxSpeed
                );

                _basicRunner.followSpeed = _currentSpeed;
            }
            _targetVector = new Vector2(Mathf.Clamp(_targetVector.x + _addValue, -LevelWidth, LevelWidth), 0.4f);
            var finaloffset = Vector2.MoveTowards(_basicRunner.motion.offset, _targetVector, _slideSpeed * Time.deltaTime);
            _basicRunner.motion.offset = finaloffset;
        }

        public void StartRunning()
        {
            _isRunning = true;
            _runTime = 0f;
            _currentSpeed = _playerStats.InitialSpeed;
            _basicRunner.followSpeed = _currentSpeed;
        }


        public enum InputMode
        {
            Menu,
            Gameplay
        }
        public InputMode CurrentInputMode { get; private set; }

        public void SwitchInput(InputMode mode)
        {
            CurrentInputMode = mode;

            switch (mode)
            {
                case InputMode.Menu:
                    _inputController.SwitchToMenu();
                    Debug.Log("Input switched to MENU");
                    break;

                case InputMode.Gameplay:
                    _inputController.SwitchToGameplay();
                    Debug.Log("Input switched to GAMEPLAY");
                    break;
            }
        }
    }
}