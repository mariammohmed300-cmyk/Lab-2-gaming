using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingPlatform : MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;

    public float speed;
    private bool AtoB;

    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = PointB.position;
        AtoB = true;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (AtoB)
            {
                targetPosition = PointA.position;
                AtoB = false;
            }
            else
            {
                targetPosition = PointB.position;
                AtoB = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        collision.transform.SetParent(transform);
    }
}

private void OnCollisionExit2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        collision.transform.SetParent(null);
    }
}
}