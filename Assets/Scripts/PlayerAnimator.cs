using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Animator playerAnimator;

    private int _moveHash;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _moveHash = Animator.StringToHash("Velocity");
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!playerMovement.IsMoving)
        {
            SetMoveAmplitude(0);
        }
        else
        {
            if (playerMovement.IsSprinting)
                SetMoveAmplitude(2);
            else
                SetMoveAmplitude(1);

            // Flip sprite based on X movement direction
            if (playerMovement.MoveDirection.x < 0)
                _spriteRenderer.flipX = true;
            else if (playerMovement.MoveDirection.x > 0)
                _spriteRenderer.flipX = false;
        }
    }

    private void SetMoveAmplitude(float value)
    {
        playerAnimator.SetFloat(_moveHash, value);
    }
}