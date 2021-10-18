using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineAnimation : MonoBehaviour
{
  LineSegments _lineSegments;
  int _linePositionIndex = 0;
  Vector3[] _linePositions;
  float _lineSegmentTimelinePosition = 0f;

  Vector3 _transformOffset;

  [SerializeField] Transport _transport;
  [SerializeField] float _beatsPrLineSegment = 0.5f;
  float _timePrLineSegment;
  float _beatsPrSecond;

  void Awake()
  {
    _lineSegments = transform.parent.GetComponent<LineSegments>();
  }
  void Start()
  {
    _transformOffset = transform.parent.transform.position;
  }

  void OnEnable()
  {
    _lineSegments.OnLineSegmentsUpdated += UpdateLineRendererPositions;
    _transport.OnBPMChanged += SetBeatsPrSecond;
    _transport.OnBPMChanged += SetTimePrLineSegment;
  }
  void OnDisable()
  {
    _lineSegments.OnLineSegmentsUpdated -= UpdateLineRendererPositions;
    _transport.OnBPMChanged -= SetBeatsPrSecond;
    _transport.OnBPMChanged -= SetTimePrLineSegment;
  }

  void Update()
  {
    if (_linePositions != null)
    {
      AnimateLineSegments();
    }
  }

  void SetBeatsPrSecond(float beatsPrSecond)
  {
    _beatsPrSecond = beatsPrSecond;
  }

  void SetTimePrLineSegment(float beatsPrSecond)
  {
    _timePrLineSegment = (_beatsPrLineSegment / beatsPrSecond);
  }

  void UpdateLineRendererPositions(Vector3[] lineRendererPositions)
  {
    _linePositions = lineRendererPositions;

    SetTimePrLineSegment(_beatsPrSecond);
  }

  void AnimateLineSegments()
  {

    Vector3 timelinePosition = new Vector3();
    bool continueToNextLineSegment;
    int nextLinePositionIndex = (_linePositionIndex + 1) % _linePositions.Length;

    timelinePosition = Vector3.Lerp(_linePositions[_linePositionIndex] + _transformOffset, _linePositions[nextLinePositionIndex] + _transformOffset, _lineSegmentTimelinePosition);

    _lineSegmentTimelinePosition += Time.deltaTime / _timePrLineSegment;
    transform.position = timelinePosition;

    continueToNextLineSegment = (timelinePosition == _linePositions[nextLinePositionIndex] + _transformOffset) ? true : false;

    if (continueToNextLineSegment)
    {
      _linePositionIndex = (_linePositionIndex + 1) % _linePositions.Length;
      _lineSegmentTimelinePosition = 0f;
    }
  }

  public float GetTimePrLineSegment() { return _timePrLineSegment; }
  public int GetNumberOfLineSegments() { return _linePositions.Length; }
}
