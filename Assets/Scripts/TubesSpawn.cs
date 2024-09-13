using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubesSpawn : MonoBehaviour
{
    public GameObject tubePrefab;
    public float distanceBetweenTubes;

    public float minY;
    public float maxY;

    private int coins = 1;

    public delegate void onCollect(int coins);
    public static event onCollect collect;

    private void Start()
    {
        GameObject tubeCopy = Instantiate(tubePrefab, new Vector3(transform.position.x + distanceBetweenTubes, Random.Range(minY, maxY)), Quaternion.identity);
        Destroy(tubeCopy, 15);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collect?.Invoke(coins++);
        GameObject tubeCopy = Instantiate(tubePrefab, new Vector3(transform.position.x + distanceBetweenTubes, Random.Range(minY, maxY)), Quaternion.identity);

        Destroy(tubeCopy, 15);
    }
}
