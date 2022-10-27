using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetFloor : MonoBehaviour
{
    float WetTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("AliveTime");
    }

    IEnumerator AliveTime()
    {
        yield return new WaitForSeconds(WetTime);
        Destroy(gameObject);
    }
}
