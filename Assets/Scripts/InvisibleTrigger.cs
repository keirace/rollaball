using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleTrigger : MonoBehaviour
{
    public List<GameObject> roadSections;
    public GameObject obstacles;
    public List<GameObject> pickups;
    // road offset
    private float offset = 50f;
    // obstacles
    private float amount = 6;
    private int lastSpawnZ = 50;
    private int spawnInterval = 20;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            SpawnRoad();
            SpawnObstacles();
        }
    }

    private void SpawnRoad()
    {
        // remove the first road section and add it to the frontmost section
        GameObject road = roadSections[0];
        roadSections.Remove(road);
        float roadSpawnZ = roadSections[roadSections.Count - 1].transform.position.z + offset;
        road.transform.position = new Vector3(0.5f, 1f, roadSpawnZ);
        roadSections.Add(road);
    }

    private void SpawnObstacles()
    {
        for (int i = 0; i < amount; i++)
        {
            // Choose a random obstacle
            int rand = Random.Range(0, obstacles.transform.childCount + 1);
            if (rand < obstacles.transform.childCount)
            {
                Transform obstacle = obstacles.transform.GetChild(rand);
                // Set pickups back to active
                foreach (Transform child in obstacle)
                {
                    child.gameObject.SetActive(true);
                }
                // Spawn the obstacle at a new z position
                Vector3 pos = obstacle.transform.position;
                Instantiate(obstacle.gameObject, new Vector3(pos.x, pos.y, lastSpawnZ), obstacle.transform.rotation);
            }
            else
            {
                SpawnPickUps();
            }
            if (i < amount - 1)
                lastSpawnZ += spawnInterval;
        }
    }

    void SpawnPickUps()
    {
        int rand = Random.Range(0, pickups.Count);
        GameObject pickup = pickups[rand];
        foreach (Transform child in pickup.transform)
        {
            child.gameObject.SetActive(true);
        }
        Vector3 pos = pickup.transform.position;
        pickups.Add(Instantiate(pickup, new Vector3(pos.x, pos.y, lastSpawnZ), pickup.transform.rotation));
    }
}
