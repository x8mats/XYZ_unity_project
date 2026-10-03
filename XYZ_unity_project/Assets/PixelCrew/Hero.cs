using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;
    
    [SerializeField] private LayerCheck _groundCheck;

    //[SerializeField] private LayerMask _groundLayer;
    //[SerializeField] private float _groundCheckRadius;
    //[SerializeField] private Vector3 _groundCheckPositionDelta;

    private Vector2 _direction;
    private Rigidbody2D _rigidbody;

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
        _rigidbody.velocity = new Vector2(_direction.x*_speed, _rigidbody.velocity.y);

        var isJumping = _direction.y > 0;

        if (isJumping)
        {
            if (isGrounded())
            {
                _rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
            }

            else if (_rigidbody.velocity.y > 0)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * 0.5f);
            }
            
        }
    }

    private bool isGrounded()
    {
        return _groundCheck.isTouchingLayer;
        //var hit = Physics2D.CircleCast(transform.position, Vector2.down, 1, _groundLayer);
        //var hit = Physics2D.CircleCast(transform.position + _groundCheckPositionDelta, _groundCheckRadius, Vector2.down, 0, _groundLayer);
        //return hit.collider != null;
        //return false;
    }
    private void OnDrawGizmos()
    {
        //Debug.DrawRay(transform.position, Vector3.down, isGrounded()? Color.green : Color.red);
        Gizmos.color = isGrounded() ? Color.green : Color.red;
        //Gizmos.DrawSphere(transform.position + _groundCheckPositionDelta, _groundCheckRadius);
        Gizmos.DrawSphere(transform.position, 0.3f);
    }
}
