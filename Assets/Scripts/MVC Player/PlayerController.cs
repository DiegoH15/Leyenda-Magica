using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerModel))]
public class PlayerController : MonoBehaviour
{
    private PlayerModel pModel;
    
    private void Start()
    {
        pModel = GetComponent<PlayerModel>();
    }
    private void Update()
    {
        Inputs();
        Movement();
        ChangeAbility();
        UseAbility();
        Rotate(pModel.mouseInput);
        CamDirection();
    }

    //-----------------------------------------------------------------------------------------
    void Inputs()
    {
        pModel.hor = Input.GetAxisRaw("Horizontal");
        pModel.ver = Input.GetAxisRaw("Vertical");
    }
    void Movement()
    {
        if (pModel.hor != 0.0f || pModel.ver != 0.0f)
        {
            Vector3 dir = transform.forward * pModel.ver + transform.right * pModel.hor;
            pModel.rb.MovePosition(transform.position + dir * pModel.speed * Time.deltaTime);
        }
    }
    void Rotate(Vector3 move)
    {
        pModel.mouseInput = new Vector3(pModel.myCamera.transform.rotation.eulerAngles.x, 0, pModel.myCamera.transform.rotation.eulerAngles.z);
        if (move.magnitude >= 0.1f)
        {

            pModel.lookCamPs = pModel.mouseInput.x * pModel.camForward;

            float targetAngle = Mathf.Atan2(pModel.lookCamPs.x, pModel.lookCamPs.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref pModel.smoothVel, 0.05f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

        }
    }
    void CamDirection()
    {
        pModel.camForward = pModel.myCamera.transform.forward;
        pModel.camRight = pModel.myCamera.transform.right;

        pModel.camForward.y = 0;
        pModel.camRight.y = 0;

        pModel.camForward = pModel.camForward.normalized;
        pModel.camRight = pModel.camRight.normalized;
    }
    //-----------------------------------------------------------------------------------------

    void ChangeAbility()
    {
        if(Input.GetKeyDown(pModel.ChangeAb) && pModel.shootAbility)
        {
            pModel.shootAbility = false;
            pModel.jumpAbility = true;
        }
        else if(Input.GetKeyDown(pModel.ChangeAb) && pModel.jumpAbility)
        {
            pModel.jumpAbility = false;
            pModel.protectAbility = true;
        }
        else if(Input.GetKeyDown(pModel.ChangeAb) && pModel.protectAbility)
        {
            pModel.protectAbility = false;
            pModel.shootAbility = true;
        }
    }

    void UseAbility()
    {
        if(pModel.shootAbility)
        {
            Shoot(15);
        }
        else if(pModel.jumpAbility)
        {
            SuperJump(20);
        }
        else if(pModel.protectAbility)
        {
            Protect(30);
        }
    }

    //-----------------------------------------------------------------------------------------


    void Shoot(float manaCost)
    { 
        if(Input.GetKey(pModel.Ability))
        {
            if(pModel.manaValue >= manaCost)
            {
                if (Time.time > pModel.shootRateTime)
                {
                    pModel.manaValue -= manaCost;
                    GameObject newBullet;

                    newBullet = Instantiate(pModel.bullet, pModel.spawnPoint.position, pModel.spawnPoint.rotation);
                    newBullet.GetComponent<Rigidbody>().AddForce(pModel.spawnPoint.forward * pModel.shootForce);
                    pModel.shootRateTime = Time.time + pModel.shootRate;
                    Destroy(newBullet, 2);
                }
            } 
        }
    }




    //--------------------------------------------------------------------------------------------

    void SuperJump(float manaCost)
    {
        if(Input.GetKeyDown(pModel.Ability) && Grounded())
        {
            if (pModel.manaValue >= manaCost)
            {
                pModel.manaValue -= manaCost;
                pModel.rb.AddForce(new Vector3(0, 70, 0), ForceMode.Impulse);
            }     
        }
    }
    bool Grounded()
    {
        if (Physics.Raycast(transform.position, Vector3.down, pModel.groundDistance, pModel.groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //-----------------------------------------------------------------------------------------------


    void Protect(float manaCost)
    {
        if (Input.GetKeyDown(pModel.Ability) && pModel.sphereForce.activeInHierarchy == false)
        {
            if (pModel.manaValue >= manaCost)
            {
                pModel.sphereForce.SetActive(true);
                pModel.manaValue -= manaCost;    
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            pModel.enemies = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            pModel.enemies = null;
        }
    }
}
