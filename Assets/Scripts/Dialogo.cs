using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    public TextMeshProUGUI textID;
    [TextArea(3,30)]
    public string[] parrafos;
    public float velParrafo;
    int index;

    public GameObject botonquitar;
    public GameObject panel;
    public GameObject botoncontinuar;
    public GameObject botonLeer;




    // Start is called before the first frame update
    void Start()
    {
        botonquitar.SetActive(false);
        panel.SetActive(false);
        botonLeer.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (textID.text == parrafos[index])
        {
            botoncontinuar.SetActive(false);
        }
    }

    IEnumerator TextDialogo()
    {
        foreach (char letra in parrafos[index].ToCharArray())
        {
            textID.text += letra;
            yield return new WaitForSeconds(velParrafo);
        }
    }

    public void SiguienteParrafo()
    {
        botoncontinuar.SetActive(false);
        if (index < parrafos.Length - 1)
        {
            index++;
            textID.text = "";
            StartCoroutine((IEnumerator)TextDialogo());

        }
        else
        {
            textID.text = "";
            botoncontinuar.SetActive(false);
            botonquitar.SetActive(true);
        }


    }

    private void OnTriggerEnter(Collider obj)
    {
        if(obj.CompareTag("Player"))
        {
            botoncontinuar.SetActive(false);
            activarbotonleer();
            
        }
        else
        {
            botoncontinuar.SetActive(false);
        }


    }

    public void activarbotonleer()
    {
        panel.SetActive(true);
        StartCoroutine((IEnumerator)TextDialogo());
    }

    public void botoncerrar()
    {
        panel.SetActive(false);
        botonLeer.SetActive(false);
    }

}
