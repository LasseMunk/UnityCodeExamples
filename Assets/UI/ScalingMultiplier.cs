using UnityEngine;

public class ScalingMultiplier : MonoBehaviour
{
 public void MultiplyScaling(float sliderValue)
 {
  float xyzScale = 0.1f * sliderValue;
  Vector3 scale = new Vector3(xyzScale, xyzScale, xyzScale);
  transform.localScale = scale;
 }
}
