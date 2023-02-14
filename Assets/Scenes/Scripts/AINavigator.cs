using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class AINavigator : MonoBehaviour
{
    public float movementSpeed = 10;
    public float rotationSpeed = 120;
    public float stopDistance = 2f;
    public Vector3 destination;
    public Animator animator;
    public bool reachedDestination;
   
    private Vector3 lastPosition;
    Vector3 velocity;

    UIHandler UIHandler;

    [SerializeField]
    bool enemy;

    private void Awake()
    {
        UIHandler = GameObject.Find("UIHandler").GetComponent<UIHandler>();
        //animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;

            float destinationDistance = destinationDirection.magnitude;

            if(destinationDistance >= stopDistance)
            {
                reachedDestination = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }    
            else
            {
                reachedDestination = true;
            }

            velocity = (transform.position - lastPosition) / Time.deltaTime;
            velocity.y = 0;
            var velocityMagnitude = velocity.magnitude;
            velocity = velocity.normalized;
            var fwdDotProduct = Vector3.Dot(transform.forward, velocity);
            var rightDotProduct = Vector3.Dot(transform.right, velocity);

            //animator.SetFloat("Horizontal", rightDotProduct);
            //animator.SetFloat("Forward", fwdDotProduct);
        }

        lastPosition = transform.position;
        
    }

    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
        reachedDestination = false;
    }

    public void Escape()
    {
        if (enemy)
        {
            UIHandler?.RemoveAlien();
            Destroy(gameObject);
        }
    }

    public void PlayDeathAnim()
    {
        animator.SetTrigger("Fall");
        float length = 0;
        RuntimeAnimatorController ac = animator.runtimeAnimatorController;
        for (int i = 0; i < ac.animationClips.Length; i++)
        {
            if (ac.animationClips[i].name.Contains("Fall"))
            {
                length = ac.animationClips[i].length;
                break;
            }
        }
        StartCoroutine(Death(length));
    }

    IEnumerator Death(float length)
    {
        yield return new WaitForSeconds(length);
        if (enemy)
        {
            UIHandler?.AddReputation(10);
            UIHandler?.AddPoints(20);
            UIHandler?.RemoveAlien();
        }
        else
        {
            UIHandler?.AddReputation(-5);
        }
        Destroy(gameObject);
    }
}
