using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyMover _template;
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private Transform _target;

    private Transform[] _points;
    private Coroutine _spawnWithDelayJob;

    private void Start()
    {
        InitializePoints();

        if (_spawnWithDelayJob != null)
            StopCoroutine(SpawnWithDelay());

        _spawnWithDelayJob = StartCoroutine(SpawnWithDelay());
    }

    private IEnumerator SpawnWithDelay()
    {
        var waitTwoSeconds = new WaitForSeconds(3);

        for (int i = 0; i < _points.Length; i++)
        {
            yield return waitTwoSeconds;
            var spawnedEnemy = Instantiate(_template, _points[i].position, Quaternion.identity);
            spawnedEnemy.Init(_target);
        }
    }

    private void InitializePoints()
    {
        _points = new Transform[_spawnPoints.childCount];

        for (int i = 0; i < _spawnPoints.childCount; i++)
            _points[i] = _spawnPoints.GetChild(i);
    }
}
