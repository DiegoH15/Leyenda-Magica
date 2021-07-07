using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemiesController : MonoBehaviour
{
    public float attackRate;
    private float atkTimer;
    public float attackForce;
    public GameObject bullet;
    private Transform player;
    public Transform spawnPoint;
    public float visionRange;
    private bool canAttack;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        
    }

    void Update()
    {
        LookAtPlayer();
        DetectPlayer();
        if (canAttack)
        {
            Shoot();
        }
    }
    void DetectPlayer()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < visionRange)
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }
    }
    void Shoot()
    {
        atkTimer += Time.deltaTime;
        if (atkTimer >= attackRate)
        {
            GameObject newBullet;
            newBullet = Instantiate(bullet);
            bullet.transform.position = spawnPoint.position;
            newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * attackForce);
            Destroy(newBullet, 3);
            atkTimer = 0;  
        }
    }
    void LookAtPlayer()
    {
        Vector3 lookPos = new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z);
        transform.rotation = Quaternion.LookRotation(lookPos);
    }
}
