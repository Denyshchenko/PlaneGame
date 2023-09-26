using System.Collections;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float MoveSpeed = 2f;

    [SerializeField] private float _lifeTime = 3f;

   
    


    private void Update()
    {
        transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);
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
        
        yield return new WaitForSeconds(_lifeTime);
        Deactivate();
    }


    private void Deactivate()
    { 
        this.gameObject.SetActive(false);
    }
}

    