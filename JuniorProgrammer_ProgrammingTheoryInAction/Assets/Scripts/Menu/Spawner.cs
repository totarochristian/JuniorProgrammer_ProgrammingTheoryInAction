using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> animalsGroups;
    [SerializeField] private float minSpawnRate = 3f;
    [SerializeField] private float maxSpawnRate = 6f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GroupsSpawnIterator());//Starts the coroutine that spawn randomly animals groups
    }
    IEnumerator GroupsSpawnIterator()
    {
        while (true)
        {
            yield return new WaitForSeconds(GenerateRandomSpawnRate());//Wait randomly time
            SpawnGroup();
        }
    }
    private float GenerateRandomSpawnRate()
    {
        return Random.Range(minSpawnRate, maxSpawnRate);
    }
    private int GenerateRandomGroupsIndex()
    {
        return Random.Range(0, animalsGroups.Count);
    }
    private void SpawnGroup()
    {
        int index = GenerateRandomGroupsIndex();//Generate random index of groups
        //Instantiate the groups in the prefab position with the prefab rotation
        Instantiate(animalsGroups[index], 
            animalsGroups[index].transform.position, 
            animalsGroups[index].transform.rotation);
    }
}
