using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public readonly List<Point> points = new();
    public readonly List<GameObject> enemys = new();

    private Vector3 position;
    private Quaternion rotation;

    public int enemyAmount = 10;
    private void Awake()
    {
        points.AddRange(GetComponentsInChildren<Point>());
    }
    private void Start()
    {
        Spawning();
    }
    private void Spawning()
    {
        for (int i = 0; i < enemyAmount; i ++)
        {
            int index = Random.Range(0, points.Count);
            SetPoint(index);
            GameObject newEnemy = Instantiate(enemyPrefab, position, rotation);
            enemys.Add(newEnemy);
        }
    }
    private void SetPoint(int index)
    {
        position = points[index].transform.position;
        rotation = points[index].transform.rotation;
    }
}
