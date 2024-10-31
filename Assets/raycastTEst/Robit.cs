// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Robit : MonoBehaviour
// {
    

//     void Update()
//     {
        

//         // rayon = new Ray(leftSensor.position, transform.TransformDirection(Vector3.forward));

//         // if (Physics.Raycast(rayon, out hit, Mathf.Infinity))
//         // {
//         //     Debug.Log("Left Sensor Objet:" + hit.collider.name + " Distance:" + hit.distance);

//         //     if (hit.distance < 1)
//         //     {
//         //         float angle = Random.Range(100f, 300f);
//         //         transform.Rotate(Vector3.up * angle * (Time.deltaTime / 4));
//         //     }
//         // }

//         // Debug.DrawRay(leftSensor.position, transform.TransformDirection(Vector3.forward) * 10f, Color.yellow);

//         // rayon = new Ray(rightSensor.position, transform.TransformDirection(Vector3.forward));

//         // if (Physics.Raycast(rayon, out hit, Mathf.Infinity))
//         // {
//         //     Debug.Log("Right Sensor Objet:" + hit.collider.name + " Distance:" + hit.distance); 

//         //     if (hit.distance < 1)
//         //     {
//         //         float angle = Random.Range(100f, 300f);

//         //         transform.Rotate(Vector3.up * angle * (Time.deltaTime / 4));
//         //     }
//         // }

//         // Debug.DrawRay(rightSensor.position, transform.TransformDirection(Vector3.forward) * 10f, Color.yellow);
//         // transform.Translate(Vector3.forward * speed * (Time.deltaTime / 4));
//     }

//     private void SensorFunction(Transform sensor, string sensorName)
//     {
//         rayon = new Ray(sensor.position, transform.TransformDirection(Vector3.forward));

//         if (Physics.Raycast(rayon, out hit, Mathf.Infinity))
//         {
//             Debug.Log("Right Sensor Objet:" + hit.collider.name + " Distance:" + hit.distance); 

//             if (hit.distance < 1)
//             {
//                 float angle = Random.Range(100f, 300f);

//                 transform.Rotate(Vector3.up * angle * (Time.deltaTime / 4));
//             }
//         }

//         Debug.DrawRay(sensor.position, transform.TransformDirection(Vector3.forward) * 10f, Color.yellow);
//         transform.Translate(Vector3.forward * speed * (Time.deltaTime / 4));
//     }
// }
