using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaballeroPoseido : MonoBehaviour
{
    public float life;
    public float lifemax;
    public int rutina;
    public float cronometro;
    public Quaternion angulo;
    public float grado;
    public bool closeToPlayer;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        UpdateLife();
    }

    public void Comportamiento_Enemigo()
    {
        if(Vector3.Distance(transform.position,target.transform.position)>6)
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
        KnockBack();
    }

    void UpdateLife()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Magia1"))
        {
            Destroy(collision.gameObject);
            life = life - 1;
            UpdateLife();
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }


    }

    public void KnockBack()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < 2)
        {
            closeToPlayer = true;
        }
        else if (Vector3.Distance(transform.position, target.transform.position) >= 2)
        {
            closeToPlayer = false;
        }
        if (closeToPlayer)
        {
            if (Input.GetKeyDown(target.GetComponent<PlayerModel>().Ability) && target.GetComponent<PlayerModel>().manaValue >= 30
                && target.GetComponent<PlayerModel>().protectAbility == true)
            {
                Vector3 dir = transform.position - target.transform.position;
                gameObject.GetComponent<Rigidbody>().AddForce(dir.normalized * target.GetComponent<PlayerModel>().knockBackForce, ForceMode.Impulse);
            }
        }
    }
}
