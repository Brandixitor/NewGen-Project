using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour
{
    public Vector3 spawnArea;
    public float speed;

    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = RandomPosition();
        StartCoroutine(patrol());
    }

    IEnumerator patrol()
    {
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                targetPosition = RandomPosition();
            }
            yield return null;
        }
    }

    Vector3 RandomPosition()
    {
        float x = Random.Range(spawnArea.x - spawnArea.x / 2, spawnArea.x + spawnArea.x / 2);
        float z = Random.Range(spawnArea.z - spawnArea.z / 2, spawnArea.z + spawnArea.z / 2);
        return new Vector3(x, transform.position.y, z);
    }
}
