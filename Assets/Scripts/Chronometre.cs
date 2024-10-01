using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Chronometre : MonoBehaviour
{

    private int chronometre = 60;

    [SerializeField] private Text chronometreText;

    // Start is called before the first frame update
    void Start()
    {
        chronometreText.text = chronometre.ToString();
        StartCoroutine(ChangerTimer());
    }

    IEnumerator ChangerTimer()
    {
        while(chronometre > 0)
        {
            chronometre --;
            chronometreText.text = chronometre.ToString();
            if(chronometre == 0)
            {
                break;
            }
            yield return new WaitForSeconds(1);
        }
        GameObject.Find("ClairePlayer").GetComponent<ClaireController>().isDead = true;
    }
}
