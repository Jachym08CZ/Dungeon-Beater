using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Transform _camera;
    float range = 10f;

    InputAction _interactAction;
    private void Awake()
    {
        _camera = Camera.main.transform;
        _interactAction = InputSystem.actions.FindAction("Interact");
    }
    private void Update()
    {
        IInteractable Target = FindTarget();
        if (Target != null && _text != null)
        {
            _text.text = Target.GetPrompt();
        }
        else
        {
            _text.text = "";
        }
        if (Target != null && _interactAction.WasPressedThisFrame())
        {
            Target.Interact(gameObject);
        }
    }
    private IInteractable FindTarget()
    {
        RaycastHit hit;
        Ray ray = new Ray(_camera.position, _camera.forward);
        if(Physics.Raycast(ray, out hit, range))
        {
            Debug.Log("Hitnul jsem nìco");
            return hit.collider.GetComponent<IInteractable>();
        }
        return null;
    }
}
