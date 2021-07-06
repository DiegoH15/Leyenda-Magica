using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeloEnemy : MonoBehaviour
{
    public float life, maxlife;    
    public int rutina;
    public float cronometro;
    public Quaternion angulo;
    public float grado;
    public bool closeToPlayer;
    public GameObject target;
    public Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("Player");
    }

   
}
