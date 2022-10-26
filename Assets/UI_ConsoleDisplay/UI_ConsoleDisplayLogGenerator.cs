using NaughtyAttributes;
using UnityEngine;

public class UI_ConsoleDisplayLogGenerator : MonoBehaviour
{

    [Button]
    private void LogRandomNumber()
    {
        Debug.Log(Random.Range(0,100));
    }
    
    [Button]
    private void LogText()
    {
        Debug.Log("This is a random text");
    }
}
