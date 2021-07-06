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
        if (Vector3.Distance(MEnemy.transform.position, target.transform.position) < 2)
        {
            closeToPlayer = true;
        }
        else if (Vector3.Distance(MEnemy.transform.position, target.transform.position) >= 2)
        {
            closeToPlayer = false;
        }
        if (closeToPlayer)
        {
            if (Input.GetKeyDown(target.GetComponent<PlayerModel>().Ability) && target.GetComponent<PlayerModel>().manaValue >= 30
                && target.GetComponent<PlayerModel>().protectAbility == true)
            {
                Vector3 dir = MEnemy.transform.position - target.transform.position;
                gameObject.GetComponent<Rigidbody>().AddForce(dir.normalized * target.GetComponent<PlayerModel>().knockBackForce, ForceMode.Impulse);
            }
        }
    }

    void Comportamiento_Enemigo()
    {
        if (Vector3.Distance(MEnemy.transform.position, MEnemy.target.transform.position) > 4)
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
                    MEnemy.transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    MEnemy.transform.Translate(Vector3.forward * 1 * Time.deltaTime);
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
