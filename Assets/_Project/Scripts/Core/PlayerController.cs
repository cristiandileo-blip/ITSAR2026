using UnityEngine;

public class PllayerController : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] Transform cameraTransform;
    private GameControls controls;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float sprintMultiplier = 1.5f;
    [SerializeField]float gravity = 10f;
    [SerializeField] float rotationSpeed = 720f;

    private void Awake() => controls = new GameControls();

    //Dopo aver assegnato un valore a gameControls ne abilitiamo la mappa Player
    private void OnEnable() => controls.Player.Enable();
    private void OnDisable() => controls.Player.Enable();
    private void OnDestroy() => controls.Dispose();

    private void Update()
    {
        Move();
        ApplyGravity();
        RotateToDirection();
    }

    void Move()
    {
        //lettura continua: valore tra -1 e 1, 1 e 1
        Vector2 input = controls.Player.Move.ReadValue<Vector2>();
        Debug.Log(input);

        float speed = moveSpeed;
        if (controls.Player.Sprint.IsPressed()) //tenuto premuto il tasto di sprint
        {
            speed *= sprintMultiplier;
        }

        Vector3 moveVector = CameraRelative(input) * speed;

        characterController.Move(moveVector * Time.deltaTime);
    }

    void ApplyGravity()
    {
        float verticalVelocity = 0;
        if (characterController.isGrounded)
        {
            verticalVelocity = -2f;
        }
        else
        {
            verticalVelocity -= gravity;
        }
        Vector3 velocity = Vector3.up * verticalVelocity;
        characterController.Move(velocity * Time.deltaTime);
    }

    void RotateToDirection()
    {
        Vector2 directionRaw = controls.Player.Move.ReadValue<Vector2>();
        Vector3 direction = CameraRelative(directionRaw);

        if (directionRaw.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private Vector3 CameraRelative(Vector2 input)
    {
        if (cameraTransform == null)
        {
            return new Vector3(input.x, 0f, input.y);
        }

        Vector3 forward = cameraTransform.forward;
        forward.y = 0f;
        forward.Normalize();

        Vector3 right = cameraTransform.right;
        right.y = 0f;
        right.Normalize();

        return Vector3.ClampMagnitude(forward * input.y + right * input.x, 1f);
    }
}