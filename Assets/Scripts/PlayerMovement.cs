using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float playerWalkSpeed = 10f;
    [SerializeField] private float playerRunSpeed = 12f;

    private float _inputX, _inputY;
    private Vector2 _moveDirection;

    public bool IsMoving { get; private set; }
    public bool IsSprinting { get; private set; }
    public Vector2 MoveDirection { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetInput()
    {
        _inputX = Input.GetAxisRaw("Horizontal");
        _inputY = Input.GetAxisRaw("Vertical");
        MoveDirection = new Vector2(_inputX, _inputY).normalized;
        IsMoving = MoveDirection != Vector2.zero;
    }

    private void Move()
    {
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? playerRunSpeed : playerWalkSpeed;
        IsSprinting = Input.GetKey(KeyCode.LeftShift);

        _moveDirection = MoveDirection * currentSpeed;
        _rigidbody.linearVelocity = _moveDirection;
    }
}