using UnityEngine;
using UnityEngine.Events;

public class OnFloorTrigger : MonoBehaviour
{
    
   [SerializeField] private UnityEvent OnFloorCollision;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with floor");
        OnFloorCollision?.Invoke();
    }
}
