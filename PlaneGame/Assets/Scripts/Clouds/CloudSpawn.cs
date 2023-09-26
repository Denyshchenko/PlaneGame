using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour
{
    [SerializeField] private int _poolCount = 9;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private Cloud _cloudContainer;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float _timeBetweenCloudSpawn;
    [SerializeField] private float _delayBeforeFirstCloudSpawn;


    private PoolCloudsMono<Cloud> _pool;

    private void Start()
    {
        this._pool = new PoolCloudsMono<Cloud>(this._cloudContainer, this._poolCount, this.transform);
        this._pool.AutoExpand = this._autoExpand;
       StartCoroutine(DelayBeforeFisrtCloud());
    }


    
    private void CreateCloud()
    {

        int randomIndex = (Random.Range(0, _spawnPoints.Count));
        Transform randomSpawnPoint = _spawnPoints[randomIndex];


        var cloud = this._pool.GetFreeElement();

        

        cloud.transform.position = randomSpawnPoint.position;

    }

    private IEnumerator DelayBeforeFisrtCloud()
    {

        
        yield return new WaitForSeconds(_delayBeforeFirstCloudSpawn);
        StartCoroutine(CloudSpawner());
    }

    private IEnumerator CloudSpawner()
    {

        CreateCloud();
        yield return new WaitForSeconds(_timeBetweenCloudSpawn);


        StartCoroutine(CloudSpawner());
    }
}
