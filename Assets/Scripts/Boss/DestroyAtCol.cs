using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtCol : MonoBehaviour
{
    public string objtag;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(objtag))
        {
            Destroy(this.gameObject);
        }
    }
}
