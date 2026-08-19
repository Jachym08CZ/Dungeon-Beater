using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTestingControls : MonoBehaviour
{
    SimplifiedFPSController _playercontroller;
    PlayerStats _playerstats;
    GameObject Player;
    InputAction _LMB;
    InputAction _crouch; // pozor zmìna z C na levý controll
    InputAction _reload; // prozatím na R

    private bool _gunMode = false;
    public GameObject SummoningCube;

    private void Awake()
    {
        this.Player = GameObject.FindWithTag("Player").gameObject;

        _playercontroller = Player.GetComponent<SimplifiedFPSController>();
        _playerstats = Player.GetComponent<PlayerStats>();
        _LMB = InputSystem.actions.FindAction("Attack");
        _crouch = InputSystem.actions.FindAction("Crouch");
        _reload = InputSystem.actions.FindAction("Reload");
    }
    void Update()
    {
        if (_LMB.WasPerformedThisFrame() && _playerstats.ManaIsRegenerating == false && _playerstats.DrainMana(10f) )
        {
            if (_gunMode == true)
            {
                ShootRayCast();
            }
            else
            {
                SummonCube();
            }
        }
        if (_crouch.WasPressedThisFrame() && _playerstats.ManaIsRegenerating == false)
        {
            if (_playercontroller.grounded == false)
            {
                Meditate();
            }
        }
        if (_crouch.WasCompletedThisFrame() && _playerstats.ManaIsRegenerating == true)
        {
            if (_playercontroller.grounded == true)
            {
                GetUp();
            }
        }

        if (_reload.WasPressedThisFrame())
        {
            _gunMode = !_gunMode;
        }
    }

    private void ShootRayCast()
    {
        RaycastHit hit;
        if(Physics.Raycast(Player.transform.position, Player.transform.forward, out hit, 50))
        {
            Debug.Log("Vystøelil");
            if(hit.transform.tag == "Enemy")
            {
                Debug.Log("ha trefa");
                GameObject _enem = hit.transform.gameObject;
                EnemyHealth health = _enem.GetComponent<EnemyHealth>();
                health.ChangeHealth(-100);
            }
        }

    }
    private void SummonCube()
    {
        GameObject clone = Instantiate
            (SummoningCube, new Vector3(Player.transform.forward.x,10, Player.transform.forward.z), Quaternion.identity);
        Destroy(clone, 5);
    }

    private void Meditate()
    {
        _playerstats.ManaRegenState(true);
        _playercontroller.SetGrounded(true);
    }


    private void GetUp()
    {
        _playerstats.ManaRegenState(false);
        _playercontroller.SetGrounded(false);
    }
}
