using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    public string playerTag;
    public float dmgValue, atkRate, lifeCD;
    public bool atkUp;
    private PlayerModel pModel;
    private void Start()
    {
        pModel = GameObject.Find("Player").GetComponent<PlayerModel>();
    }
    private void Update()
    {
        if(atkUp)
        {
            lifeCD += Time.deltaTime;
            if(lifeCD >= atkRate)
            {
                atkUp = false;
                lifeCD = 0;
            }
        }
    }
    void GeneralAttack(float dmgValue)
    {
        if(atkUp == false)
        {
            pModel.life -= dmgValue;
            atkUp = true;
        }      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            GeneralAttack(dmgValue);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            GeneralAttack(dmgValue);
        }
    }
}
