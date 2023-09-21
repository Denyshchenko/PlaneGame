using System.Collections;
using UnityEngine;


public class Cloud : MonoBehaviour
{
    [SerializeField] private float lifeTime = 3f;

    public float moveSpeed = 2f;    

    
    private void Update()
    {
       
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        this.StartCoroutine(LifeTime());  
    }

    private void OnDisable()
    {
        this.StopCoroutine(LifeTime());
    }



    private IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(lifeTime);
        Deactivate();
    }

    private void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}

