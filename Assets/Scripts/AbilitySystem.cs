using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class AbilitySystem : MonoBehaviour
{
    InputController controls;
    PlayerMovement movement;
    List<GameObject> spawnObjects;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<PlayerMovement>();
        controls = new InputController();
        controls.PlayerMovement.Ability.performed += PerformAbility;
        controls.PlayerMovement.Ability.Enable();
    }

    void PerformAbility(CallbackContext ctx)
    {
        int x = Mathf.RoundToInt(transform.position.x);
        int z = Mathf.RoundToInt(transform.position.z);
        Vector3 SpawnPos = new Vector3(x, transform.position.y, z);
        Vector3 dir = movement.GetDir().normalized;
        dir.x = Mathf.CeilToInt(dir.x);
        dir.z = Mathf.CeilToInt(dir.y);
        GameObject newObj = Instantiate(spawnObjects[0]);
        newObj.transform.position = SpawnPos + dir;
        
    }
}
