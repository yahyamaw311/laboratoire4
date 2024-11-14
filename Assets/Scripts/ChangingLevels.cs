using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangingLevels : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] string SceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == player.transform.GetComponent<Collider>())
        {
            Debug.Log("le joueur a passe au prochain nivrau");
            SceneManager.LoadScene("afterLevel1");
        }
    }
}
