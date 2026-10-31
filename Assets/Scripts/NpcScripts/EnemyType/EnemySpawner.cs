using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject unit;
    private float couldown = 3;
    public int maxUnits = 10;
    private int curUnits = 0;

    private void Update()
    {
        if (curUnits < maxUnits)
        {
            couldown -= Time.deltaTime;

            if (couldown <= 0.0f)
            {
                SpawnUnit();
            }
        }

    }
    void SpawnUnit()
    {
        Vector3 spawnPos = gameObject.transform.position;
        GameObject newUnit = Instantiate(unit, spawnPos, Quaternion.identity);
        couldown = 3;
        maxUnits++;
    }
}
