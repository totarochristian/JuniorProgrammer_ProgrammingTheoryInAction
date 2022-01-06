using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterToDestroy : MonoBehaviour
{
    [SerializeField] private float timeToDestroy = 10f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            timeToDestroy -= 1f;
            if (timeToDestroy <= 0)
                Destroy(gameObject);
        }
    }
}
