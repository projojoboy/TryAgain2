using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _MovementSpeed = 10f;
    [SerializeField] private float _SwipeThreshold = 20f;

    [SerializeField] private bool _OnlyDetectSwipeAfterRelease = false;

    private CharacterController2D _CC;

    private float _HorizontalMove = 0f;
    private float _HorizontalInput = 0f;

    private bool _Jump = false;
    private bool _DetectedSwipe = false;

    private Vector2 _FingerUp;
    private Vector2 _FingerDown;

    private void Awake()
    {
        _CC = GetComponent<CharacterController2D>();
        OnUIButtonPress.JumpEvent += ActivateJump;
        OnUIButtonPress.MoveEvent += SetHorizontalMove;
    }

    private void Update()
    {
        _HorizontalMove = _HorizontalInput * _MovementSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
            _Jump = true;
    }

    private void FixedUpdate()
    {
        _CC.Move(_HorizontalMove * Time.deltaTime, false, _Jump);
        _Jump = false;
    }

    public void ActivateJump() { _Jump = true; }
    public void SetHorizontalMove(float _HMove) { _HorizontalInput = _HMove; }
}
