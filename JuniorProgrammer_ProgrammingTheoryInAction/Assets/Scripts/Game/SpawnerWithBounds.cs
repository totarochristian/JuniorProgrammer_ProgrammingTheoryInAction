using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerWithBounds : MonoBehaviour
{
    [SerializeField] protected List<GameObject> animalsGroups;
    [SerializeField] private int animalMaxInMaps;
    [SerializeField] private float posXMin;
    [SerializeField] private float posXMax;
    [SerializeField] private float posYMin;
    [SerializeField] private float posYMax;
    [SerializeField] private float posZMin;
    [SerializeField] private float posZMax;
    void Start()
    {
        StartCoroutine(GroupsSpawnIterator());//Starts the coroutine that spawn randomly animals groups
    }
    IEnumerator GroupsSpawnIterator()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);//Wait 1 sec
            if (GameObject.FindGameObjectsWithTag("Animal").Length < animalMaxInMaps / 2)
            {
                SpawnGroup();
            }
        }
    }
    protected int GenerateRandomGroupsIndex()
    {
        return Random.Range(0, animalsGroups.Count);
    }
    void SpawnGroup()
    {
        for(int i = 0; i < animalMaxInMaps; i++)
        {
            int index = GenerateRandomGroupsIndex();//Generate random index of animals
            //Instantiate the animal in a random position with the prefab rotation
            Instantiate(animalsGroups[index],
                GeneratePosition(),
                animalsGroups[index].transform.rotation);
        }
    }
    private float GenerateAxisValue(float min, float max)
    {
        return Random.Range(min, max);
    }
    private Vector3 GeneratePosition()
    {
        return new Vector3(GenerateAxisValue(posXMin, posXMax),
            GenerateAxisValue(posYMin, posYMax),
            GenerateAxisValue(posZMin, posZMax));
    }
}
