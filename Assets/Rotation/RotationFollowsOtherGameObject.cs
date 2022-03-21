using UnityEngine;

namespace FollowGameObjectRotation
{
public class RotationFollowsOtherGameObject : MonoBehaviour
{
    [SerializeField] private Transform otherGameObjectTransform;
    
    void Update()
    {
        Vector3 newEuler = new Vector3(0f, otherGameObjectTransform.eulerAngles.y, 0f);
        transform.eulerAngles = newEuler;
    }
}
}
