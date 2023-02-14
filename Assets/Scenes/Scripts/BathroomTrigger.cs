using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomTrigger : MonoBehaviour
{
    private Animation anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<AINavigator>().Escape();
            //anim = gameObject.GetComponent<Animation>();
            //anim["falling"].layer = 123;
        }
    }
    void DestroyObjectDelayed()
    {
        if (anim["falling"])
        {
            Destroy(gameObject, 2);
        }
    }
}
