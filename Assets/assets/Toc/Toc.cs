using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Toc : MonoBehaviour
{
    public int life;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Magia1"))
        {
            life -= 5;
        }
    }
}
