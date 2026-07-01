using UnityEngine;
using UnityEngine.InputSystem; // nov˝ Input System

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;
    public float groundedStickForce = 2f; // malÈ p¯itlaËenÌ k zemi

    [Header("Look")]
    public float mouseSensitivity = 0.1f; // n·sobÌ delta myöi
    public float minPitch = -90f;
    public float maxPitch = 90f;
    public Transform playerCamera; // odkaz na kameru (child) ñ nastav v Inspectoru

    // Input System (p¯es PlayerInput)
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _lookAction;
    private InputAction _jumpAction;

    private CharacterController _cc;
    private float _pitch;         // akumulovan· vertik·lnÌ rotace (X)
    private Vector3 _velocity;    // vnit¯nÌ rychlost (vË. Y)

    void Awake()
    {
        _cc = GetComponent<CharacterController>();
        _playerInput = GetComponent<PlayerInput>();
        if (_playerInput == null)
        {
            Debug.LogError("P¯idej na Player komponentu PlayerInput a p¯i¯aÔ akce (Action Map: Player).");
        }
        if (playerCamera == null)
        {
            Debug.LogWarning("ChybÌ reference na kameru");
        }
    }

    void OnEnable()
    {
        if (_playerInput != null && _playerInput.actions != null)
        {
            _moveAction = _playerInput.actions.FindAction("Move");
            _lookAction = _playerInput.actions.FindAction("Look");
            _jumpAction = _playerInput.actions.FindAction("Jump");

            // BezpeËÌ, aù neh·ûe NRE, kdyû akce neexistuje
            _moveAction?.Enable();
            _lookAction?.Enable();
            _jumpAction?.Enable();
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnDisable()
    {
        _moveAction?.Disable();
        _lookAction?.Disable();
        _jumpAction?.Disable();
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        if (_playerInput == null) return;

        // --- LOOK (myö/gamepad) ---
        Vector2 look = _lookAction.ReadValue<Vector2>();


        // U myöi je look v pixelech per-frame; ök·luj citlivostÌ a neVIS Time.deltaTime
        float yaw = look.x * mouseSensitivity;
        float pitchDelta = -look.y * mouseSensitivity;

        _pitch = Mathf.Clamp(_pitch + pitchDelta, minPitch, maxPitch);
        // otoËenÌ tÏla (yaw)
        transform.Rotate(0f, yaw, 0f);
        // otoËenÌ kamery (pitch)
        if (playerCamera != null)
            playerCamera.localRotation = Quaternion.Euler(_pitch, 0f, 0f);

        // --- MOVE (WASD) ---
        Vector2 moveInput = _moveAction.ReadValue<Vector2>(); // x=strafe, y=forward
        Vector3 move = (transform.right * moveInput.x + transform.forward * moveInput.y) * moveSpeed;

        // --- GRAVITY + JUMP ---
        if (_cc.isGrounded)
        {
            // drû lehce z·pornou Y, aby Ñneplavalì na hran·ch
            _velocity.y = -groundedStickForce;

            if (_jumpAction.triggered)
            {
                _velocity.y = jumpSpeed;
            }
        }
        else
        {
            _velocity.y -= gravity * Time.deltaTime;
        }

        // kombinace horizont·lnÌho pohybu + vertik·lnÌ rychlosti
        Vector3 finalVelocity = new Vector3(move.x, _velocity.y, move.z);
        _cc.Move(finalVelocity * Time.deltaTime);
    }
}