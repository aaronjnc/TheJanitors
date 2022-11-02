using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WetFloor : MonoBehaviour
{
    float WetTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("AliveTime");
    }

    private void OnTriggerEnter(Collider other)
    {
        AINavigator ai = other.gameObject.GetComponent<AINavigator>();
        if (ai != null)
        {
            ai.PlayDeathAnim();
            Destroy(gameObject);
        }
    }

    IEnumerator AliveTime()
    {
        yield return new WaitForSeconds(WetTime);
        Destroy(gameObject);
    }
}
