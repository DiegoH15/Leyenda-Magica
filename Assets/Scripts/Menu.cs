using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Animator animFade;

    public void Scene()
    {
        animFade.SetBool("Oculto", true);
        StartCoroutine(Load());

        IEnumerator Load()
        {
            yield return new WaitForSeconds(3.0f);
            SceneManager.LoadScene("TerrainScene");
        }
    }

    public void MenuPrincipal()
    {
        animFade.SetBool("Oculto", true);
        StartCoroutine(Load());

        IEnumerator Load()
        {
            yield return new WaitForSeconds(3.0f);
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Menu");
        }
    }

    public void Pagina()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCJrceJ9pXR5EQYkaxgd1jzw?view_as=subscriber");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
