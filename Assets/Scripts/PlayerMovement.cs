using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    InputController controls;
    Rigidbody rb;
    Vector2 dir;

    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controls = new InputController();
        controls.PlayerMovement.Movement.performed += Move;
        controls.PlayerMovement.Movement.canceled += StopMove;
        controls.PlayerMovement.Movement.Enable();

        //controls.UI.Pause.performed += TogglePause;
        //controls.UI.Pause.Enable();
    }

    void Move(CallbackContext ctx)
    {
        dir = speed * ctx.ReadValue<Vector2>().normalized;
        rb.velocity = new Vector3(dir.x, 0, dir.y);
    }

    void StopMove(CallbackContext ctx)
    {
        rb.velocity = Vector3.zero;
    }
}
