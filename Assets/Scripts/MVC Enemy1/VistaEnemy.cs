using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VistaEnemy : MonoBehaviour
{
    private ModeloEnemy MEnemy;
    // Start is called before the first frame update
    void Start()
    {
        MEnemy = GetComponent<ModeloEnemy>();
    }
   
    void UpdateLife()
    {
        

        if (MEnemy.life >= MEnemy.maxlife)
        {
            MEnemy.life = MEnemy.maxlife;
        }
        if (MEnemy.life <= 0)
        {
            MEnemy.life = 0;
            gameObject.SetActive(false);
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        UpdateLife();
    }
}
