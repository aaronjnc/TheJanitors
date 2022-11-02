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
    Animator animator;
    [SerializeField]
    GameObject mop;
    [SerializeField]
    Vector3[] mopPositions;
    // Start is called before the first frame update
    void Start()
    {
        animator = mop.GetComponent<Animator>();
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
        Vector2 dir = movement.GetDir().normalized;
        dir.x = Mathf.CeilToInt(dir.x);
        dir.y = Mathf.CeilToInt(dir.y);
        if (dir == Vector2.zero)
            dir = Vector2.down;
        string state = "";
        if (dir.y >= 1)
        {
            state = "Up";
            mop.transform.localPosition = mopPositions[0];
        }
        else if (dir.y <= -1) 
        {
            state = "Down";
            mop.transform.localPosition = mopPositions[1];
        }
        else if (dir.x >= 1)
        {
            state = "Right";
            mop.transform.localPosition = mopPositions[2];
        }
        else
        {
            state = "Left";
            mop.transform.localPosition = mopPositions[3];
        }
        mop.SetActive(true);
        animator.SetTrigger(state);
        float length = 0;
        RuntimeAnimatorController ac = animator.runtimeAnimatorController;
        for (int i = 0; i < ac.animationClips.Length; i++)
        {
            if (ac.animationClips[i].name == state + "Anim")
            {
                length = ac.animationClips[i].length;
            }
        }
        IEnumerator coroutine = MopTime(hazard, new Vector3(dir.x, 0, dir.y), length);
        StartCoroutine(coroutine);
    }

    IEnumerator MopTime(GameObject hazard, Vector3 dir, float length)
    {
        yield return new WaitForSeconds(length);
        mop.SetActive(false);
        int x = Mathf.RoundToInt(transform.position.x);
        int z = Mathf.RoundToInt(transform.position.z);
        Vector3 SpawnPos = new Vector3(x, transform.position.y, z);
        GameObject newObj = Instantiate(hazard);
        newObj.transform.position = SpawnPos + dir;
    }
}
