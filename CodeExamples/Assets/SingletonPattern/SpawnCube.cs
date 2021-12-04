using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace SingletonPattern
{
  public class SpawnCube : MonoBehaviour
  {
    float maxRange = 10f;
    [SerializeField] GameObject cubePrefab;

    [Button]
    [ContextMenu("SpawnAtRandomPosition")]
    void SpawnCubeAtRandomPosition()
    {
      int x = (int)Random.Range(0f, maxRange);
      int y = (int)Random.Range(0f, maxRange);
      int z = (int)Random.Range(0f, maxRange);

      Vector3 position = new Vector3(x, y, z);

      GameObject spawnedCube = Instantiate(cubePrefab, position, Quaternion.identity);
      GameEnvironment.Instance.AddCubeToList(spawnedCube);
    }

    [Button]
    void DestroyAllCubes()
    {
      List<GameObject> allCubes = GameEnvironment.Instance.GetCubesInGame();
      GameEnvironment.Instance.RemoveAllCubesFromList();

      for (int i = 0; i < allCubes.Count; i++)
      {
        Destroy(allCubes[i]);
      }
    }
  }
}
