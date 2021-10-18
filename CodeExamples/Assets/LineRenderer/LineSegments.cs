using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(LineRenderer))]
public class LineSegments : MonoBehaviour
{
  public event Action<Vector3[]> OnLineSegmentsUpdated;

  [SerializeField] RaycastSelect raycastSelect;
  BoxCollider _thisBoxCollider;

  int maxSegments = 16;
  int minSegments = 2;
  [SerializeField] [Range(2, 16)] int _segments;
  float maxRadius = 10f;
  float minRadius = 1f;
  [SerializeField] [Range(1f, 10f)] float _radius;

  LineRenderer _line;

  void Awake()
  {
    _thisBoxCollider = GetComponent<BoxCollider>();
    if (raycastSelect != null)
      _line = gameObject.GetComponent<LineRenderer>();

  }

  void OnEnable()
  {
    raycastSelect.OnRaycastObjectHit += ConvertRaycastHitPointToLineSegments;
  }
  void OnDisable()
  {
    raycastSelect.OnRaycastObjectHit -= ConvertRaycastHitPointToLineSegments;
  }

  void Start()
  {
    _line.useWorldSpace = false;
    UpdateLineSegments(_segments, _radius);
  }

  void OnValidate()
  {
    UpdateLineSegments(_segments, _radius);
  }

  public void SetNumberOfLineSegments(float segments)
  {
    _segments = (int)segments;
    if (_segments < minSegments) _segments = minSegments;
    if (_segments > maxSegments) _segments = maxSegments;

    UpdateLineSegments(_segments, _radius);
  }

  public void SetRadius(float radius)
  {
    _radius = radius;
    if (_radius < minRadius) _radius = minRadius;
    if (_radius > maxRadius) _radius = maxRadius;

    UpdateLineSegments(_segments, _radius);
  }

  public float GetRadius() { return _radius; }

  void ConvertRaycastHitPointToLineSegments(RaycastHit raycastHit)
  {
    if (raycastHit.collider == _thisBoxCollider)
    {
      float yHitPosition = raycastHit.transform.InverseTransformPoint(raycastHit.point).y;
      float yHitPositionWithOffset = yHitPosition + (_thisBoxCollider.size.y / 2);
      float relativeHitPosition = (yHitPositionWithOffset / _thisBoxCollider.size.y);

      int newLineSegmentCount = (int)(maxSegments * relativeHitPosition);

      SetNumberOfLineSegments(newLineSegmentCount);
    }
  }

  void UpdateLineSegments(int segments, float radius)
  {
    if (_line == null) return;

    _line.positionCount = segments + 1;

    float x;
    float y;
    float z = 0f;

    float angleOfRotation = 0f;

    for (int i = 0; i < (segments + 1); i++)
    {
      x = Mathf.Sin(Mathf.Deg2Rad * angleOfRotation) * radius;

      y = Mathf.Cos(Mathf.Deg2Rad * angleOfRotation) * radius;

      _line.SetPosition(i, new Vector3(x, y, z));

      angleOfRotation += (360f / segments);
    }

    OnLineSegmentsUpdated?.Invoke(GetLineRendererPositions());
  }

  public LineRenderer GetLineRenderer()
  {
    return _line;
  }

  Vector3[] GetLineRendererPositions()
  {
    Vector3[] positions = new Vector3[_line.positionCount];
    _line.GetPositions(positions);

    return positions;
  }
}