using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset
        = new Vector3(0f, 16f, -11f);
 
    // più è alto, più la camera è morbida
    [SerializeField] private float smoothTime = 0.15f;
 
    // stato interno
    private Vector3 velocity;
 
    // LateUpdate: dopo tutti gli Update,
    // quando il player si è già mosso
    private void LateUpdate()
    {
        if (target == null) return;
 
        Vector3 desired = target.position + offset;
    
        transform.position = Vector3.SmoothDamp(
            transform.position,   // da dove parte
            desired,              // dove vuole arrivare
            ref velocity,         // memoria tra i frame
            smoothTime);          // quanto è morbido

        Vector3 fromCamTopPlayer = target.position - transform.position;
        Quaternion desiredRotation = Quaternion.LookRotation(fromCamTopPlayer);

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            desiredRotation,
            720f * Time.deltaTime);

    }

}

