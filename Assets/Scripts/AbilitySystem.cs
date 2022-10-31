using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class AbilitySystem : MonoBehaviour
{
    InputController controls;
    PlayerMovement movement;
    [SerializeField]
    GameObject WetSpot;
    //0 - Up
    //1 - Down
    //2 - Right
    //3 - Left
    [SerializeField]
    RuntimeAnimatorController[] Controllers;
    [SerializeField]
    Animator mopAnimator;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<PlayerMovement>();
        controls = new InputController();
        controls.PlayerMovement.Ability.performed += WetFloor;
        controls.PlayerMovement.Ability.Enable();
    }

    void WetFloor(CallbackContext ctx)
    {
        SpawnObject(WetSpot);
    }

    void SpawnObject(GameObject hazard)
    {
        int x = Mathf.RoundToInt(transform.position.x);
        int z = Mathf.RoundToInt(transform.position.z);
        Vector3 SpawnPos = new Vector3(x, transform.position.y, z);
        Vector2 dir = movement.GetDir().normalized;
        dir.x = Mathf.CeilToInt(dir.x);
        dir.y = Mathf.CeilToInt(dir.y);
        if (dir == Vector2.zero)
            dir = Vector2.up;
        if (dir.y == 1)
        {
            mopAnimator.runtimeAnimatorController = Controllers[0];
        }
        else if (dir.y == -1)
        {
            mopAnimator.runtimeAnimatorController = Controllers[1];
        }
        else if (dir.x == 1)
        {
            mopAnimator.runtimeAnimatorController = Controllers[2];
        }
        else
        {
            mopAnimator.runtimeAnimatorController = Controllers[3];
        }
        mopAnimator.Play();
        GameObject newObj = Instantiate(hazard);
        newObj.transform.position = SpawnPos + new Vector3(dir.x, 0, dir.y);
    }
}
