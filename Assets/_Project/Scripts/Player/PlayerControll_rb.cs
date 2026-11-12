using UnityEngine;

public class PlayerControll_rb : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 input;
    private GameControls controls;
    [SerializeField] private float force = 50f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); //getComponent cerca il component e il primo che trova lo assegna alla variabile rb
        controls = new GameControls();
    }

    private void OnEnable() => controls.Player.Enable();
    private void OnDisable() => controls.Player.Disable();
    private void OnDestroy() => controls.Dispose();

    private void Update()    
    {
        input = controls.Player.Move.ReadValue<Vector2>();
        Debug.Log(input);
    }

    private void FixedUpdate()
    {
        Vector3 input3 = new Vector3(input.x, 0f, input.y);
        Vector3 velocity = input3 * force;
        // rb.AddForce(input3 * force);

        rb.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
    }



}
