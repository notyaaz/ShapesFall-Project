using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GameObject particlePrefap;

    GameObject particale;
    private void OnMouseDown()
    {
        if (GameManager.instance.isDead == false)
        {
             Destroy(gameObject);
            AudioManager.instance.PlaySound("CoinSound");
            particale = Instantiate(particlePrefap, transform.position, Quaternion.identity);
            Destroy(particale, 1.5f);
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 1);
        }


    }
}
