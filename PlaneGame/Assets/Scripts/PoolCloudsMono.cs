using System.Collections.Generic;
using UnityEngine;

public class PoolCloudsMono<T> where T : MonoBehaviour
{

    public T prefab { get; }
    public bool autoExpand { set; get; }
    public Transform container { get; }


    public List<T> pool;


    public PoolCloudsMono(T prefab, int count, Transform container)
    {
        this.prefab = prefab;
        this.container = container;

        this.CreatePool(count);
    }

    private void CreatePool(int count)
    {
        this.pool = new List<T>();

        for (int i = 0; i < count; i++)
            this.CreateObject();

    }


    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = Object.Instantiate(this.prefab, this.container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        this.pool.Add(createdObject);

        return createdObject;
    }

    public bool HasFreeElement(out T element)
    {
        foreach (var cloudMono in pool)
        {
            if (!cloudMono.gameObject.activeInHierarchy)
            {
                element = cloudMono;
                cloudMono.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }


    public T GetFreeElement()
    {
        if (this.HasFreeElement(out var element))
            return element;



        if (this.autoExpand)
            return this.CreateObject(true);


        throw new System.Exception("No free elements in pool");

    }
}
