using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class SimplifiedFPSController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;
    public float groundedStickForce = 2f;

    [Header("Look")]
    public float mouseSensitivity = 0.1f;
    public float minPitch = -90f;
    public float maxPitch = 90f;
    public Transform playerCamera;

    private InputAction _moveAction;
    private InputAction _lookAction;
    private InputAction _jumpAction;

    private InputAction _sprintAction;


    private CharacterController _cc;
    private float _pitch;
    private Vector3 _velocity;

    [Header("Events")]
    private PlayerStats playerstats;

    private void Awake()
    {
        _cc = GetComponent<CharacterController>();
        playerstats = GetComponent<PlayerStats>();

        _moveAction = InputSystem.actions.FindAction("Move");
        _lookAction = InputSystem.actions.FindAction("Look");
        _jumpAction = InputSystem.actions.FindAction("Jump");

        _sprintAction = InputSystem.actions.FindAction("Sprint");

        if (playerCamera == null)
            Debug.LogWarning("Chybí reference na kameru");
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        // --- LOOK ---
        Vector2 look = _lookAction.ReadValue<Vector2>();
        float yaw = look.x * mouseSensitivity;
        float pitchDelta = -look.y * mouseSensitivity;

        _pitch = Mathf.Clamp(_pitch + pitchDelta, minPitch, maxPitch);
        transform.Rotate(0f, yaw, 0f);

        if (playerCamera != null)
            playerCamera.localRotation = Quaternion.Euler(_pitch, 0f, 0f);

        // --- MOVE ---
        Vector2 moveInput = _moveAction.ReadValue<Vector2>();
        Vector3 move = (transform.right * moveInput.x + transform.forward * moveInput.y) * moveSpeed;

        // --- GRAVITY + JUMP ---
        if (_cc.isGrounded)
        {
            _velocity.y = -groundedStickForce;

            if (_jumpAction.WasPerformedThisFrame())
            { 
                _velocity.y = jumpSpeed;
                playerstats.DrainStamina(5);
                playerstats.IsDrained = true;
            }
            else
            {
                playerstats.IsDrained = false;
            }
        }
        else
        {
            _velocity.y -= gravity * Time.deltaTime;
        }

        if (_sprintAction.IsPressed())
        {
            moveSpeed = 12;
            playerstats.DrainStamina(0.5f);
            playerstats.IsDrained = true;
        }
        else
        {
            playerstats.IsDrained = false;
            moveSpeed = 6;
        }
        Vector3 finalVelocity = new Vector3(move.x, _velocity.y, move.z);
        _cc.Move(finalVelocity * Time.deltaTime);
    }
}