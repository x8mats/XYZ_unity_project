using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _horizontalDirection;
    private float _verticalDirection;

    public void SetHorizontalDirection(float direction)
    {
        _horizontalDirection = direction;
    }

    public void SetVerticalDirection(float direction)
    {
        _verticalDirection = direction;
    }

    private void Update()
    {
        Vector3 direction = new Vector3(_horizontalDirection, _verticalDirection, 0f);

        direction = direction.normalized;

        transform.position += direction * _speed * Time.deltaTime;

    }
}
