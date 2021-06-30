using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerModel : MonoBehaviour
{
    //-------Basics------------
    public float life, maxlife;
    public float speed;
    public float hor, ver;
    public Vector3 mouseInput, camForward, camRight;
    public Transform myCamera;
    public Vector3 lookCamPs;
    public float smoothVel = .1f;
    public float groundDistance;

    //---------Abilities-------------
    public bool shootAbility, jumpAbility, protectAbility;
    public float manaValue, maxMana;
    public KeyCode Ability;
    public KeyCode ChangeAb;

    //---------ShootAbility---------
    public GameObject bullet;
    public Transform spawnPoint;
    public float shootForce;
    public float shootRate;
    [HideInInspector]
    public float shootRateTime;

    //----------JumpAbility----------
    public LayerMask groundLayer;


    //---------ProtectAbility----------
    public float knockBackForce;
    public GameObject enemies;
    public int enemiesIndex = 0;
    public GameObject sphereForce, ground;
    public float sphereTime;

    //--------Components----------
    [HideInInspector]
    public Rigidbody rb;


    private void Start()
    {    
        myCamera = GameObject.Find("Main Camera").GetComponent<Transform>();
        sphereForce = GameObject.Find("SphereForce");
        ground = GameObject.FindGameObjectWithTag("Ground");
        Physics.IgnoreCollision(sphereForce.GetComponent<SphereCollider>(), ground.GetComponent<BoxCollider>());
        sphereForce.SetActive(false);
        rb = GetComponent<Rigidbody>();
        shootAbility = true;
        jumpAbility = false;
        protectAbility = false;
    }
}
