using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceToTarget;
    [SerializeField] private Transform[] _points;

    private int _currentPoint;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float distance = (_points[_currentPoint].transform.position - transform.position).magnitude;

        if (distance <= _distanceToTarget)
            _currentPoint++;

        if (_currentPoint >= _points.Length)
            _currentPoint = 0;      

        transform.position = Vector3.MoveTowards(transform.position, _points[_currentPoint].transform.position, Time.deltaTime * _speed);
    }
}
