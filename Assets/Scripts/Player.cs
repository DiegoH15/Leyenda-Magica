using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float life;
    public int maxHP;
    public float maxlife;
    private new Rigidbody rigidbody;
    public float speed = 10f;
    public GameObject bulletPrefab;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        maxlife = life;
        UpdateLife();
    }

    // Update is called once per frame
    void Update()
    {

        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        if (hor != 0.0f || ver != 0.0f)
        {
            Vector3 dir = transform.forward * ver + transform.right * hor;
            rigidbody.MovePosition(transform.position + dir * speed * Time.deltaTime);
        }


    }

    void Health()
    {
        if (life > maxHP)
        {
            life = maxHP;
        }
    }

    void UpdateLife()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            life = life - 30;
            UpdateLife();
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }



}
