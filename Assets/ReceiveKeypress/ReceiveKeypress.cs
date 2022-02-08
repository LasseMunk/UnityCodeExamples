using UnityEngine;

namespace ReceiveKeypress
{
public class ReceiveKeypress : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space was pressed");
        }
    }
}
}
