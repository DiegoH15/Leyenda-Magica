using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaballeroPoseido : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Quaternion angulo;
    public float grado;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    public void Comportamiento_Enemigo()
    {
        if(Vector3.Distance(transform.position,target.transform.position)>4)
        {
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 2)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;

                case 1:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    break;
            }


        }
        else
        {
            var LookPoos = target.transform.position - transform.position;
            LookPoos.y = 0;
            var rotation = Quaternion.LookRotation(LookPoos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);


            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Comportamiento_Enemigo();
    }

    
}
