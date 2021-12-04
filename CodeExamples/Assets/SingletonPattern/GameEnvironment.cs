using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SingletonPattern
{
  public sealed class GameEnvironment
  {
    // sealed means no other class can inherit from this class
    private static GameEnvironment instance;
    public static GameEnvironment Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new GameEnvironment();
        }
        return instance;
      }
    }

    List<GameObject> cubesInGame = new List<GameObject>();

    public void AddCubeToList(GameObject cube)
    {
      cubesInGame.Add(cube);
    }

    public List<GameObject> GetCubesInGame()
    {
      return cubesInGame;
    }

    public void RemoveAllCubesFromList()
    {
      cubesInGame = new List<GameObject>();
    }
  }
}