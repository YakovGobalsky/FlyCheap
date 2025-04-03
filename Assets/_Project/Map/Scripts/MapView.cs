using System.Collections.Generic;
using UnityEngine;

namespace FlyCheap
{
  public class MapView<T>: MonoBehaviour where T : IMarker
  {
    protected readonly List<T> _markers = new();

    public virtual void ClearMarkers ()
    {
      foreach (var marker in _markers)
      {
        marker.DestroyMarker();
      }
      _markers.Clear();
    }

    public virtual T AddMarker (Vector2 pos) {
      var marker = CreateMarkerImpl(pos);
      _markers.Add(marker);
      return marker;
    }

    protected virtual T CreateMarkerImpl (Vector2 pos) => default;
	}
}