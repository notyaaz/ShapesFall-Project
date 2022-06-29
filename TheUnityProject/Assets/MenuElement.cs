using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuElement : MonoBehaviour
{
    private void OnMouseDown()
    {
        if(this.gameObject.name == "PLAY")
        {
            SceneManager.LoadScene("PlayScene");
        }
        if (this.gameObject.name == "EXIT")
        {
            Application.Quit();
        }

    }
}
