using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorEnemy : MonoBehaviour
{
    private ModeloEnemy MEnemy;
    

    // Start is called before the first frame update
    private void Start()
    {
        MEnemy = GetComponent<ModeloEnemy>();
    }

    // Update is called once per frame
    private void Update()
    {
        Comportamiento_Enemigo();
        KnockBack();
        
    }

    void KnockBack()
    {
        if (Vector3.Distance(MEnemy.transform.position, MEnemy.target.transform.position) < 2)
        {
            MEnemy.closeToPlayer = true;
        }
        else if (Vector3.Distance(MEnemy.transform.position, MEnemy.target.transform.position) >= 2)
        {
            MEnemy.closeToPlayer = false;
        }
        if (MEnemy.closeToPlayer)
        {
            if (Input.GetKeyDown(MEnemy.target.GetComponent<PlayerModel>().Ability) && MEnemy.target.GetComponent<PlayerModel>().manaValue >= 30
                && MEnemy.target.GetComponent<PlayerModel>().protectAbility == true)
            {
                Vector3 dir = MEnemy.transform.position - MEnemy.target.transform.position;
                gameObject.GetComponent<Rigidbody>().AddForce(dir.normalized * MEnemy.target.GetComponent<PlayerModel>().knockBackForce, ForceMode.Impulse);
            }
        }
    }

    void Comportamiento_Enemigo()
    {
        if (Vector3.Distance(MEnemy.transform.position, MEnemy.target.transform.position) > 4)
        {
            MEnemy.cronometro += 1 * Time.deltaTime;
            if (MEnemy.cronometro >= 2)
            {
                MEnemy.rutina = Random.Range(0, 2);
                MEnemy.cronometro = 0;
            }
            switch (MEnemy.rutina)
            {
                case 0:
                    MEnemy.grado = Random.Range(0, 360);
                    MEnemy.angulo = Quaternion.Euler(0, MEnemy.grado, 0);
                    MEnemy.rutina++;
                    break;

                case 1:
                    MEnemy.transform.rotation = Quaternion.RotateTowards(transform.rotation, MEnemy.angulo, 0.5f);
                    MEnemy.transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    break;
            }


        }
        else
        {
            var LookPoos = MEnemy.target.transform.position - transform.position;
            LookPoos.y = 0;
            var rotation = Quaternion.LookRotation(LookPoos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);


            transform.Translate(Vector3.forward * 2 * Time.deltaTime);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Magia1"))
        {
            MEnemy.enemies = other.gameObject;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Magia1"))
        {
            MEnemy.enemies = null;
        }
    }
}
