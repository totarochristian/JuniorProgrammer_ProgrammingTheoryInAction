using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftAnimalEndless : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private float xLimit = -7f;
    void FixedUpdate()
    {
        Move();
        CheckBounds();
    }
    private void Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);//Move the object to the left using the speed
    }
    private void CheckBounds()
    {
        //If the group x position is less then the limit
        if (transform.position.x < xLimit)
            Destroy(gameObject);//Destroy the gameObject
    }
}
