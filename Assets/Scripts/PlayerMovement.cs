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
    [SerializeField]
    GameObject playerSprite;
    Animator animator;
    SpriteRenderer spriteRenderer;
    //0 - up
    //1 - down
    //2 - right
    //3 - left
    [SerializeField]
    Sprite[] BaseSprites;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = playerSprite.GetComponent<Animator>();
        spriteRenderer = playerSprite.GetComponent<SpriteRenderer>();
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
        string state = "";
        if (dir.x < 0)
        {
            state = "WalkRight";
        }
        else if (dir.x > 0)
        {
            state = "WalkLeft";
        }
        else if (dir.y > 0)
        {
            state = "WalkUp";
        }
        else
        {
            state = "WalkDown";
        }
        if (animator.enabled == false)
            animator.enabled = true;
        animator.Play(state);
    }

    void StopMove(CallbackContext ctx)
    {
        Vector3 vel = rb.velocity;
        animator.enabled = false;
        if (vel.x < 0)
        {
            spriteRenderer.sprite = BaseSprites[2];
        }
        else if (vel.x > 0)
        {
            spriteRenderer.sprite = BaseSprites[3];
        }
        else if (vel.z < 0)
        {
            spriteRenderer.sprite = BaseSprites[0];
        }
        else
        {
            spriteRenderer.sprite = BaseSprites[1];
        }
        rb.velocity = Vector3.zero;
    }

    public Vector2 GetDir()
    {
        return dir;
    }
}
