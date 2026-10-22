using UnityEngine;

public class PulseLight : MonoBehaviour
{
    [Header("Riferimenti")]
    [Tooltip("Se vuoto, cerca il Renderer su questo oggetto o nei figli")]
    [SerializeField] private Renderer targetRenderer;

    [Header("Emission")]
    [ColorUsage(false, true)]
    [SerializeField] private Color emissionColor = Color.cyan;
    [SerializeField, Min(0f)] private float minIntensity = 0.5f;
    [SerializeField, Min(0f)] private float maxIntensity = 3f;

    [Header("Pulsazione")]
    [Tooltip("Pulsazioni al secondo")]
    [SerializeField, Min(0f)] private float frequency = 0.5f;

    private static readonly int EmissionColorId = Shader.PropertyToID("_EmissionColor");

    private MaterialPropertyBlock propertyBlock;

    private void Awake()
    {
        if (targetRenderer == null)
            targetRenderer = GetComponentInChildren<Renderer>();

        propertyBlock = new MaterialPropertyBlock();

        // Abilita la keyword emission sul materiale (necessario in URP Lit)
        targetRenderer.sharedMaterial.EnableKeyword("_EMISSION");
    }

    private void Update()
    {
        // Sine normalizzato da 0 a 1
        float t = (Mathf.Sin(Time.time * frequency * Mathf.PI * 2f) + 1f) * 0.5f;
        float intensity = Mathf.Lerp(minIntensity, maxIntensity, t);

        targetRenderer.GetPropertyBlock(propertyBlock);
        propertyBlock.SetColor(EmissionColorId, emissionColor * intensity);
        targetRenderer.SetPropertyBlock(propertyBlock);
    }
}