using System.Collections.Generic;
using UnityEngine;

public class RandomCloudPrefabActivate : MonoBehaviour
{

    [SerializeField] private List<GameObject> cloudPrefabs;



    private GameObject currentCloudPrefab;


    void ActivateRandomCloudPrefab()
    {
        int activeObjectCount = 0;

        foreach (GameObject obj in cloudPrefabs)
        {

            if (obj.activeSelf)
            {
                activeObjectCount++;
            }
        }

        if (activeObjectCount < 1)
        {

            int randomIndex = (Random.Range(0, cloudPrefabs.Count));
            currentCloudPrefab = cloudPrefabs[randomIndex];
            currentCloudPrefab.SetActive(true);
        }
    }

    private void OnEnable()
    {
        ActivateRandomCloudPrefab();
        

    }

    private void OnDisable()
    {
        currentCloudPrefab.SetActive(false);
    }
}
