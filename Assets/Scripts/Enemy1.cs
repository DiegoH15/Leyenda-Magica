using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public Transform target;
    public float speed = 4f;
    public int life;
    Rigidbody rig;
    public float btimer;
    public float maxShoot;
    public GameObject BulletPrefaps;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        rig.MovePosition(pos);
        transform.LookAt(target);
    }

    void Btimer()
    {
        btimer = btimer + Time.deltaTime;
        if (btimer >= maxShoot)
        {
            GameObject obj = Instantiate(BulletPrefaps);
            obj.transform.position = transform.position;
            btimer = btimer - maxShoot;
        }
    }



    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Magia1"))
        {
            Destroy(collision.gameObject);

            life = life - 10;           
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

   
}
