// https://www.udemy.com/course/design-patterns-for-game-programming/learn/lecture/14640536#content

using UnityEngine;
using UnityEditor;
using NaughtyAttributes;

namespace SaveGenerativePrefab
{
  public class SpawnCube : MonoBehaviour
  {
    float maxRange = 10f;
    [SerializeField] GameObject cubePrefab;
    GameObject lastCreatedCube;

    [Button]
    [ContextMenu("SpawnCubeWithRandomScale")]
    void SpawnCubeWithRandomScale()
    {
      GameObject spawnedCube = Instantiate(cubePrefab, Vector3.zero, Quaternion.identity);

      Vector3 newLocalScale = new Vector3(
          Random.Range(0.1f, maxRange),
          Random.Range(0.1f, maxRange),
          Random.Range(0.1f, maxRange)
      );

      spawnedCube.transform.localScale = newLocalScale;
      spawnedCube.name = $"cube_{Time.time}";
      lastCreatedCube = spawnedCube;
    }

    [Button]
    void SaveAsPrefab()
    {
      string path;
      string prefabPath;
      string filename;

      path = Application.dataPath + "/SaveGenerativePrefab/Prefabs";
      prefabPath = "Assets/SaveGenerativePrefab/Prefabs";
      filename = lastCreatedCube.name;

      //   System.IO.Directory.CreateDirectory(path);
      //   AssetDatabase.CreateAsset(lastCreatedCube, $"{prefabPath}/{filename}.asset");
      //   AssetDatabase.SaveAssets();
      if (lastCreatedCube != null)
      {
        PrefabUtility.SaveAsPrefabAsset(lastCreatedCube, $"{prefabPath}/{filename}.prefab");
      }
      else
      {
        Debug.Log("lastCreatedCube is null");
      }
    }
  }
}