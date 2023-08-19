using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;

    public void Init(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        Move(_target);
    }

    public void Move(Transform target)
    {
        float distance = (target.position - transform.position).magnitude;

        if(distance > 0.1)
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * _speed);
    }
}
