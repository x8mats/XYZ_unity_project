using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private LayerCheck _groundCheck;

    private Vector2 _direction;
    private Rigidbody2D _rigidbody;
    private bool _hasJumped;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(
            _direction.x * _speed,
            _rigidbody.velocity.y
        );

        bool isJumpButtonHeld = _direction.y > 0;

        if (isJumpButtonHeld && isGrounded() && !_hasJumped)
        {
            _rigidbody.AddForce(
                Vector2.up * _jumpSpeed,
                ForceMode2D.Impulse
            );

            _hasJumped = true;
        }

        if (!isJumpButtonHeld && _rigidbody.velocity.y > 0)
        {
            _rigidbody.velocity = new Vector2(
                _rigidbody.velocity.x,
                _rigidbody.velocity.y * 0.5f
            );
        }

        if (isGrounded() && !isJumpButtonHeld)
        {
            _hasJumped = false;
        }
    }

    private bool isGrounded()
    {
        return _groundCheck != null && _groundCheck.isTouchingLayer;
    }
}