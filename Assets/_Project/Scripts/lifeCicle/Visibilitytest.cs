using UnityEngine;

public class VisibilityTest : MonoBehaviour
{
    [SerializeField] Variabletest vt;
    private void Start()
    {
        if (vt != null)
        {
            Debug.Log($"{vt.shopIndex}");
        }
    }
}
