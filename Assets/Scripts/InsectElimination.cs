using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectElimination : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float jumpingDistance;
    [SerializeField] int jumpCount;
    [SerializeField] LayerMask groundLayers;
    [SerializeField] GameObject particles;
    Rigidbody rb;
    CapsuleCollider col;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        col = player.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // if ()
        // {
        //     jumpCount++;
        //     Debug.Log("Insecte sauteur: " + jumpCount);
        // }
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if(IsGrounded() && Input.GetKeyDown(KeyCode.Space) && distanceToPlayer < jumpingDistance)
        {
            jumpCount++;
            Debug.Log("Insecte sauteur: " + jumpCount);
            
            // StartCoroutine(ActivateParticles(transform.Find("DamageParticles").gameObject));
            StartCoroutine(ActivateParticles(particles));
        }
    }

    IEnumerator ActivateParticles(GameObject damageParticles)
    {
        damageParticles.SetActive(true);
        yield return new WaitForSeconds(2);
        damageParticles.SetActive(false);
        
        if(jumpCount == 2)
        {
            transform.gameObject.SetActive(false);
        }
    }

    

    private bool IsGrounded(){
        return Physics.CheckCapsule(col.bounds.center, 
        new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
    }
}
