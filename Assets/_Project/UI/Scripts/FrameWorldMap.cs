using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyCheap
{
  public class FrameWorldMap: FrameSceneObject
	{
    [SerializeField] private SingleImageMap _mapView;

    public SingleImageMap GetMapView () => _mapView;
	}
}