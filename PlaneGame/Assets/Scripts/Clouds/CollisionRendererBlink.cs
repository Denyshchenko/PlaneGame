using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionRendererBlink : MonoBehaviour
{



    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material awareMaterial;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlaneController>())
        {
            StartCoroutine(Blink());
        }
    }


    private IEnumerator Blink()
    {
       
        for (int i = 0; i < 5; i++)
        {
            gameObject.GetComponentInChildren<Renderer>().material = awareMaterial;
            yield return new WaitForSeconds(0.2f);
            gameObject.GetComponentInChildren<Renderer>().material = defaultMaterial;
            yield return new WaitForSeconds(0.2f);
        }

        StopCoroutine(Blink());
       // gameObject.SetActive(false);
    }


   
}
