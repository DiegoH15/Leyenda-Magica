using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerModel))]
public class PlayerView : MonoBehaviour
{
    private PlayerModel pModel;
    private Image vida;
    private Image mana;
    private Text abilityText;
    // Start is called before the first frame update
    void Start()
    {
        vida = GameObject.Find("Vida").GetComponent<Image>();
        mana = GameObject.Find("Mana").GetComponent<Image>();
        abilityText = GameObject.Find("abilityText").GetComponent<Text>();
        pModel = GetComponent<PlayerModel>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void VidaUpdate()
    {
        vida.fillAmount = pModel.life / pModel.maxlife;

        if (pModel.life >= pModel.maxlife)
        {
            pModel.life = pModel.maxlife;
        }
        if (pModel.life <= 0)
        {
            pModel.life = 0;
            gameObject.SetActive(false);
        }
        pModel.life += 2 * Time.deltaTime;
    }

    void ManaUpdate()
    {
        mana.fillAmount = pModel.manaValue / pModel.maxMana;
        if(pModel.manaValue >= pModel.maxMana)
        {
            pModel.manaValue = pModel.maxMana;
        }
        if(pModel.manaValue <= 0)
        {
            pModel.manaValue = 0;
        }
        pModel.manaValue += 2 * Time.deltaTime;
    }
    void AbilityUpdate()
    {
        if(pModel.shootAbility)
        {
            abilityText.text = "Hechizo: Bolas de fuego";
        }
        else if(pModel.jumpAbility)
        {
            abilityText.text = "Hechizo: Impulso del viento";
        }
        else if(pModel.protectAbility)
        {
            abilityText.text = "Hechizo: Escudo eléctrico";
        }
    }
    void EscudoElectricoVisuals()
    {
        if (pModel.sphereForce.activeInHierarchy == true)
        {
            pModel.sphereTime += Time.deltaTime;
            if (pModel.sphereTime >= 3f)
            {
                pModel.sphereForce.SetActive(false);
                pModel.sphereTime = 0;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        VidaUpdate();
        ManaUpdate();
        AbilityUpdate();
        EscudoElectricoVisuals();
    }
}
