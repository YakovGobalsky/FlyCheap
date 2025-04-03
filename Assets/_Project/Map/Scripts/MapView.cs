using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

namespace FlyCheap
{
  public class MapView<T>: MonoBehaviour, IControlledWorlMap where T:IMarker
  {
    protected readonly List<T> _markers = new ();

    public virtual Vector2 Center { get; protected set; }

    public virtual void ClearMarkers()
    {
      foreach (var marker in _markers)
      {
        marker.DestroyMarker();
      }
      _markers.Clear ();
    }

    public virtual T AddMarker (Vector2 pos) {
      var marker = CreateMarkerImpl(pos);
      _markers.Add(marker);
			return marker;
    }

    public virtual void CenterAt(Vector2 pos) => Center = pos;

    public virtual void Shift(Vector2 delta) => Center += delta;

    protected virtual T CreateMarkerImpl (Vector2 pos) => default;
	}
}