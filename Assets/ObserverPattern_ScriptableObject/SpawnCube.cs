using UnityEngine;
using NaughtyAttributes;

public class SpawnCube : MonoBehaviour
{
  float maxRange = 10f;
  [SerializeField] GameObject cubePrefab;

  [Header("Events")]
  public Event cubeSpawned;

  [Button]
  [ContextMenu("SpawnAtRandomPosition")]
  void SpawnCubeAtRandomPosition()
  {
    int x = (int)Random.Range(0f, maxRange);
    int y = (int)Random.Range(0f, maxRange);
    int z = (int)Random.Range(0f, maxRange);

    Vector3 position = new Vector3(x, y, z);

    GameObject spawnedCube = Instantiate(cubePrefab, position, Quaternion.identity);
    cubeSpawned.Triggered(spawnedCube); // trigger event whenever a cube is spawned
  }
}
