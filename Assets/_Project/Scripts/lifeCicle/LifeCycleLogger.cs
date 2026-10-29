using UnityEngine;

public class LifeCycleLogger : MonoBehaviour
{

    void Awake()
    {
        Debug.Log($"Esegue Awake di {gameObject.name}");
    }

    void OnEnable()
    {
        Debug.Log($"Esegue OnEnable di {gameObject.name}");    
    }

    void Start()
    {
        Debug.Log($"Esegue Start di {gameObject.name}");
    }

    void Update()
    {
        Debug.Log($"Esegue Update di {gameObject.name}");
    }

     private void FixedUpdate()
    {
        Debug.Log($"Esegue FixedUpdate di {gameObject.name}");
    }

    //è chiamato al termine del ciclo update/fixeUpdate
    void LateUpdate()
    {
        Debug.Log($"Esegue LateUpdate di {gameObject.name}");
        
    }

    //è chiamato alla disattivazione dell'oggetto
    void OnDisable()
    {
        Debug.Log($"Esegue OnDisable di {gameObject.name}");
    }

    //è chiamato alla distruzione dell'oggetto
    private void OnDestroy()
    {
        Debug.Log($"Esegue OnDestroy di {gameObject.name}");
    }

    }