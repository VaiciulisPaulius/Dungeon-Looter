using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sawblade : MonoBehaviour
{
    // Start is called before the first frame update
    Transform[] waypoints;
    Vector3 currTarget;
    [SerializeField] [Range(0f, 10f)] float sawbladeSpeed;
    [SerializeField] float damage;
    //int i;
    void Start()
    {
        Transform parentTransform = transform.parent;
        // Loop through all children of the parent transform
        waypoints = new Transform[parentTransform.childCount - 1];
        Debug.Log(parentTransform.childCount - 1);
        for (int i = 1; i < parentTransform.childCount; i++)
        {
            waypoints[i - 1] = parentTransform.GetChild(i);
            // Do something with the child transform, such as accessing its position or other components
        }

        transform.position = waypoints[0].position;
        StartCoroutine(FollowPath());
    }
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, -500f * Time.deltaTime));
    }
    IEnumerator FollowPath()
    {
        int i = 1;
        while(true)
        {
            yield return StartCoroutine(Move(waypoints[i].position, sawbladeSpeed));
            if (i == waypoints.Length - 1) i = 0;
            else i++;
        }
    }
    IEnumerator Move(Vector2 destination, float speed)
    {
        while((Vector2) transform.position != destination)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
