using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTestingControls : MonoBehaviour
{
    GameObject Player;
    InputAction PressH; // doopravdy to je Levý tlaèítko :( jsem línej to mìnit
    private void Start()
    {
        this.Player = GameObject.FindWithTag("Player").gameObject;
        PressH = InputSystem.actions.FindAction("Attack");
    }
    void Update()
    {
        if (PressH.WasPerformedThisFrame())
        {
            Player.GetComponent<PlayerHealthScript>().ChangeHealth(-50);
        }
    }
}
