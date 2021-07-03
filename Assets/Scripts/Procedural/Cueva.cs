using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cueva : MonoBehaviour
{
   
    public GameObject[] objarray = new GameObject[9];
    public Transform[] positionArray = new Transform[9];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < objarray.Length; i++)
        {
            Instantiate(objarray[i]);
            objarray[i].transform.position = positionArray[i].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
