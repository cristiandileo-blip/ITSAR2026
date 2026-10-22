using UnityEngine;

/// <summary>
/// Fa oscillare l'oggetto sulla verticale reale del mondo (asse Y world)
/// usando un'onda sinusoidale, tra un offset minimo e uno massimo.
/// Indipendente dalle rotazioni del genitore o dell'oggetto stesso.
/// Da assegnare all'oggetto Core (o a un suo genitore, vedi nota).
/// </summary>
public class UpDown : MonoBehaviour
{
    [Header("Limiti (offset rispetto alla posizione iniziale)")]

    // Distanza minima dalla posizione iniziale (punto più basso).
    // Può essere negativa.
    [SerializeField] private float minOffset = -0.25f;

    // Distanza massima dalla posizione iniziale (punto più alto).
    [SerializeField] private float maxOffset = 0.25f;

    [Header("Movimento")]

    // Numero di oscillazioni complete al secondo.
    // Esempio: 0.5 = un ciclo completo ogni 2 secondi.
    [Tooltip("Oscillazioni complete al secondo")]
    [SerializeField, Min(0f)] private float frequency = 0.5f;

    // Posizione in world space di partenza, salvata all'avvio.
    // Serve come riferimento a cui sommare l'offset calcolato.
    private Vector3 startWorldPos;

    private void Start()
    {
        // Memorizza la posizione iniziale in coordinate del mondo,
        // così l'oscillazione non dipende dalla rotazione dei genitori.
        startWorldPos = transform.position;
    }

    private void Update()
    {
        // Sine rimappato da -1..1 a 0..1.
        // Time.time * frequency * 2π: "frequency" = cicli completi al secondo.
        float t = (Mathf.Sin(Time.time * frequency * Mathf.PI * 2f) + 1f) * 0.5f;

        // Interpola tra minOffset (t = 0) e maxOffset (t = 1)
        float offset = Mathf.Lerp(minOffset, maxOffset, t);

        // Applica l'offset solo sulla Y del mondo (Vector3.up = (0, 1, 0)).
        // X e Z restano fissi alla posizione iniziale.
        transform.position = startWorldPos + Vector3.up * offset;
    }
}