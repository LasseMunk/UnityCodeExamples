using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineAnimation : MonoBehaviour
{
  LineSegments _lineSegments;
  Coroutine _lineAnimation;

  [SerializeField] float _beatsPrMinute = 120;
  [SerializeField] float _beatsPrSecond;
  [SerializeField] float _beatsPrLineSegment = 0.125f;
  [SerializeField] float _timePrLineSegment;
  [SerializeField] float _animationVelocity;

  void Awake()
  {
    _lineSegments = transform.parent.GetComponent<LineSegments>();
  }

  void OnEnable()
  {
    _lineSegments.OnLineSegmentsUpdated += StartAnimatingTimeline;
  }
  void OnDisable()
  {
    _lineSegments.OnLineSegmentsUpdated -= StartAnimatingTimeline;
  }
  void Start()
  {
    CalculateAnimationVelocity();
  }
  void OnValidate()
  {
    CalculateAnimationVelocity();
  }
  void CalculateAnimationVelocity()
  {
    _beatsPrSecond = CalculateBeatsPrSecond(_beatsPrMinute);
    _timePrLineSegment = CalculateTimePrLineSegment(_beatsPrSecond);
  }
  float CalculateBeatsPrSecond(float beatsPrMinute) { return (beatsPrMinute / 60); }
  float CalculateTimePrLineSegment(float beatsPrSecond) { return (_beatsPrLineSegment / beatsPrSecond); }

  [ContextMenu("StartAnimatingTimeline")]
  void StartAnimatingTimeline()
  {
    if (_lineAnimation != null) StopCoroutine(_lineAnimation);
    _lineAnimation = StartCoroutine(AnimateLineSegments());
  }

  IEnumerator AnimateLineSegments()
  {
    Vector3[] linePositions = _lineSegments.GetLineRendererPositions();

    Vector3 timelinePosition = new Vector3();
    int linePositionIndex = 0;
    float lineSegmentPosition = 0f;
    bool animationIsFinished = false;
    bool continueToNextLineSegment;


    while (!animationIsFinished)
    {
      timelinePosition = Vector3.Lerp(linePositions[linePositionIndex], linePositions[linePositionIndex + 1], lineSegmentPosition);

      lineSegmentPosition += _timePrLineSegment * Time.deltaTime;
      transform.position = timelinePosition;

      continueToNextLineSegment = (timelinePosition == linePositions[linePositionIndex + 1]) ? true : false;

      if (continueToNextLineSegment)
      {
        animationIsFinished = (timelinePosition == linePositions[linePositions.Length - 1]) ? true : false;

        linePositionIndex++;
        lineSegmentPosition = 0f;
      }

      yield return null;
    }
  }
}
