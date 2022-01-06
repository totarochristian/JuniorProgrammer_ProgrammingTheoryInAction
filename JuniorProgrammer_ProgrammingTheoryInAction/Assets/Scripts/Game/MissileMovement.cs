using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float time;
    private Rigidbody missileRb;
    void Start()
    {
        missileRb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * force * Time.deltaTime);
    }
    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
            Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        string name = collision.gameObject.name;
        if (!collision.gameObject.CompareTag("Terrain"))
        {
            PlayerData pd = MainManager.instance.GetPlayerData();
            if (name.Contains("Horse"))
                pd.SetHorses(pd.GetHorses() + 1);
            else if (name.Contains("Rooster"))
                pd.SetRoosters(pd.GetRoosters() + 1);
            else if (name.Contains("Cow"))
                pd.SetCows(pd.GetCows() + 1);
            else if (name.Contains("Chicken"))
                pd.SetChickens(pd.GetChickens() + 1);
            else if (name.Contains("Chick"))
                pd.SetChicks(pd.GetChicks() + 1);
            GameObject.Find("Animals Points").GetComponent<AnimalsPoints>().UpdatePoints();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
