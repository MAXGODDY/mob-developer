using Controllers.Input;
using Dreamteck.Forever;
using TMPro;
using UnityEngine;


namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        private InputController _inputController;
        [SerializeField] private Runner _basicRunner;
        [SerializeField] private float _slideSpeed = 5f;
        [SerializeField] private float _joystickSlow = 2f;
        [SerializeField] Animator _animator;
        [SerializeField] TMP_Text _text;

        private const string RunningBool = "IsRunning";
        private const string JumpingTrigger = "IsJumping";

        private Vector2 _targetVector;

        private float _addValue;
        private const int LevelWidth = 5;

        private void Awake()
        {
            _inputController = new();
            _inputController.SubscribeEvents();
            _animator.SetBool(RunningBool, true);
            SubsribeEvents();
        }

        private void Start()
        {
            Coin._text = _text;
            DamageOnCollision._animator = _animator;
        }


        private void SubsribeEvents()
        {
            _inputController.MovementRecieved += OnMovementRecieved;
            _inputController.MovementEnd += OnMovementEndd;
            _inputController.JumpStarted += OnJumpPressed;
        }

        private void UnsudscribeEvents()
        {
            _inputController.MovementRecieved -= OnMovementRecieved;
            _inputController.MovementEnd -= OnMovementEndd;
            _inputController.JumpStarted -= OnJumpPressed;
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

            UpdateMovement();
        }

        private void OnMovementEndd()
        {
            _targetVector = _basicRunner.motion.offset;
            _addValue = 0;
        }

        private void UpdateMovement()
        {
            //_basicRunner.motion.offset = new Vector2(_targetX, _basicRunner.motion.offset.y);
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