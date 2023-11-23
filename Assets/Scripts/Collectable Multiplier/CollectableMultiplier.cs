using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMultiplier : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject collectablePrefab;

    public void SpawnSmallCollectables()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                float distance = 0.3f;
                Vector3 position = transform.position + new Vector3(i * distance, 0, j * distance);
                SpawnCollectable(position);
            }
        }

        Vector3 lastPosition = transform.position + new Vector3(0, 0, 0.8f);
        SpawnCollectable(lastPosition);

        Destroy(gameObject);
    }

    private void SpawnCollectable(Vector3 position)
    {
        GameObject spawnedObject =  Instantiate(collectablePrefab, position, Quaternion.identity);
        Collectable collectable = spawnedObject.GetComponent<Collectable>();
        collectable.PlaySpawnAnimation();
    }
}
