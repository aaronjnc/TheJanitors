using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class AbilitySystem : MonoBehaviour
{
    InputController controls;
    List<GameObject> spawnObjects;
    // Start is called before the first frame update
    void Start()
    {
        controls.PlayerMovement.Ability.performed += PerformAbility;
    }

    void PerformAbility(CallbackContext ctx)
    {
        GameObject newObj = Instantiate(spawnObjects[0]);
    }
}
