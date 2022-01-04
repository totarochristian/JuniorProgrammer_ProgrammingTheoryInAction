using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftEndless : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    private Vector3 startPos;
    private float limitXPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;//Save the initial position
        limitXPos = GetComponent<BoxCollider>().size.x / 2;//Get the width/2 of the object
    }
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
        //If the object x position is less then the limit
        if (transform.position.x < startPos.x - limitXPos)
            transform.position = startPos;//Reset the position
    }
}
