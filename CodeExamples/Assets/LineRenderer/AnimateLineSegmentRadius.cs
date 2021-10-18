using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateLineSegmentRadius : MonoBehaviour
{
  LineSegments _lineSegments;
  [SerializeField] TimelineAnimation _timelineAnimation;

  void Awake()
  {
    _lineSegments = this.GetComponent<LineSegments>();
  }

  [ContextMenu("StartExpandRadiusOverTime")]
  void StartExpandRadiusOverTime()
  {
    float minRadius = CalculateMinRadius();
    float maxRadius = _lineSegments.GetRadius();
    float lerpTime = CalculateInterpolationTime();

    StartCoroutine(AnimateRadiusOverTime(minRadius, maxRadius, lerpTime));
  }

  float CalculateInterpolationTime()
  {
    float timePrLineSegment = _timelineAnimation.GetTimePrLineSegment();
    float numberOfLineSegments = _timelineAnimation.GetNumberOfLineSegments();
    float lerpTime = timePrLineSegment * numberOfLineSegments;

    return lerpTime;
  }

  float CalculateMinRadius()
  {
    float minRadius = _lineSegments.GetRadius() - 1;
    if (minRadius < 0) minRadius = 0;

    return minRadius;
  }

  IEnumerator AnimateRadiusOverTime(float minRadius, float maxRadius, float lerpTime)
  {
    float lerpPosition = 0.0f;
    float newRadius;

    while (Time.time < (Time.time + lerpTime))
    {
      lerpPosition += Time.deltaTime / lerpTime;
      newRadius = Mathf.Lerp(minRadius, maxRadius, lerpPosition);

      _lineSegments.SetRadius(newRadius);

      yield return null;
    }
  }
}
