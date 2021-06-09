using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image vida;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        vida = GameObject.Find("Vida").GetComponent<Image>();
        player = GameObject.Find("Player");
    }

    void VidaUpdate()
    {
        vida.fillAmount = player.GetComponent<Player>().life/player.GetComponent<Player>().lifemax;
        if(player.GetComponent<Player>().life>=10)
        {
            player.GetComponent<Player>().life = 10;
        }
        if(player.GetComponent<Player>().life<=0)
        {
            player.GetComponent<Player>().life = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        VidaUpdate();
        if (Input.GetKeyDown(KeyCode.K))
        {
            player.GetComponent<Player>().life-=3;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            player.GetComponent<Player>().life += 3;
        }

        
    }
}
