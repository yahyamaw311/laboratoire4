using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] public static int speed = 5;      // Vitesse de déplacement vers le joueur
    [SerializeField] public static float activationDistance = 7.0f;  // Distance d'activation de l'ennemi
    private Animator animator;      // Référence à l'Animator
    UnityEngine.AI.NavMeshAgent agent;

    // for raycast
    [SerializeField] Transform leftSensor, rightSensor;
    Ray rayon;
    RaycastHit hit;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(target == null){
            return;
        }

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= activationDistance)
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
        } else
        {
            agent.isStopped = true;
            SensorFunction(leftSensor, "Left Sensor");
            SensorFunction(rightSensor, "Right Sensor");
        }
    }


    private void SensorFunction(Transform sensor, string sensorName)
    {
        rayon = new Ray(sensor.position, transform.TransformDirection(Vector3.forward));

        if (Physics.Raycast(rayon, out hit, Mathf.Infinity))
        {
            Debug.Log("Right Sensor Objet:" + hit.collider.name + " Distance:" + hit.distance); 

            if (hit.distance < 1)
            {
                float angle = Random.Range(100f, 300f);

                transform.Rotate(Vector3.up * angle * (Time.deltaTime / 4));
            }
        }

        Debug.DrawRay(sensor.position, transform.TransformDirection(Vector3.forward) * 10f, Color.yellow);
        transform.Translate(Vector3.forward * speed * (Time.deltaTime / 4));
    }
}
