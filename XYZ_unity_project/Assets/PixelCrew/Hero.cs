using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private float _direction;

    [SerializeField] private float _speed;

    public void SetDirection(float direction)
    {
        _direction = direction;
    }

    private void Update()
    {
        if (_direction != 0)
        {
            var delta = _direction * _speed * Time.deltaTime;
            var newYPosition = transform.position.y + delta;
            var newXPosition = transform.position.x + delta;
            transform.position = new Vector3(newXPosition, newYPosition, transform.position.z);


        }
    }
}
