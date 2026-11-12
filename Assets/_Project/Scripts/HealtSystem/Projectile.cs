using UnityEngine;

public class Projectle : MonoBehaviour
{
    [SerializeField] float damage = 5f;
    [SerializeField] float speed = 10f;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Health _health))
        {
            _health.TakeDamage(damage);
        }
        Destroy(this.gameObject);
        
    }
}
