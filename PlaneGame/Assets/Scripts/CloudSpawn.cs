using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour
{
    [SerializeField] private int poolCount = 9;
    [SerializeField] private bool autoExpand = false;
    [SerializeField] private Cloud cloudPrefab;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private float timeBetweenCloudSpawn; 



    private PoolCloudsMono<Cloud> pool;

    private void Start()
    {
        this.pool = new PoolCloudsMono<Cloud>(this.cloudPrefab, this.poolCount, this.transform);
        this.pool.autoExpand = this.autoExpand;
        StartCoroutine(CloudSpawner());
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.CreateCloud();
        }

        
    }

    private void CreateCloud()
    {
        
        int randomIndex = (Random.Range(0, spawnPoints.Count));
        Transform randomTransform = spawnPoints[randomIndex];

        
        var cloud = this.pool.GetFreeElement();
        cloud.transform.position = randomTransform.position;
        
    }

    private IEnumerator CloudSpawner()
    {

        CreateCloud();
        yield return new WaitForSeconds(timeBetweenCloudSpawn);

        
        StartCoroutine(CloudSpawner());
    }
}
