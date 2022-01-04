using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private int life;
    [SerializeField] private int lifeMax = 10;
    [SerializeField] private float speed = 4f;
    [SerializeField] private float movementRateMax = 2f;
    [SerializeField] private float eatTimeMax = 4f;

    private bool move = false;
    private Vector3 direction;

    private Animator animalAnim;
    void Start()
    {
        animalAnim = GetComponent<Animator>();
        life = lifeMax;
        StartCoroutine(RandomMovement());
    }
    void Update()
    {
        if (move)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (life <= 0)
            Destroy(gameObject);
    }
    public void Damage(int power)
    {
        life -= power;
    }
    IEnumerator RandomMovement()
    {
        while (life > 0)
        {
            animalAnim.SetFloat("Speed_f", 0);
            yield return new WaitForSeconds(Random.Range(0, eatTimeMax));
            animalAnim.SetFloat("Speed_f", 1);
            move = true;
            ChangeDirection();
            yield return new WaitForSeconds(Random.Range(0, movementRateMax));
            move = false;
        }
    }
    public Vector3 RandomDirection()
    {
        Vector3[] dir = new Vector3[] { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
        int i = Random.Range(0, dir.Length);
        return dir[i];
    }
    private void ChangeDirection()
    {
        direction = RandomDirection();

        if (direction == Vector3.right)
        {
            transform.Rotate(new Vector3(0, 90, 0));
        }else if (direction == Vector3.left)
        {
            transform.Rotate(new Vector3(0, -90, 0));
        }
        else if (direction == Vector3.back)
        {
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
