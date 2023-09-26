using System.Collections.Generic;
using UnityEngine;

public class PoolCloudsMono<T> where T : MonoBehaviour
{

    public T Prefab { get; }
    public bool AutoExpand { set; get; }
    public Transform Container { get; }


    public List<T> Pool;


    public PoolCloudsMono(T prefab, int count, Transform container)
    {
        this.Prefab = prefab;
        this.Container = container;

        this.CreatePool(count);
    }

    private void CreatePool(int count)
    {
        this.Pool = new List<T>();

        for (int i = 0; i < count; i++)
            this.CreateObject();

    }


    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = Object.Instantiate(this.Prefab, this.Container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        this.Pool.Add(createdObject);

        return createdObject;
    }

    public bool HasFreeElement(out T element)
    {
        foreach (var cloudMono in Pool)
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



        if (this.AutoExpand)
            return this.CreateObject(true);


        throw new System.Exception("No free elements in pool");

    }
}
