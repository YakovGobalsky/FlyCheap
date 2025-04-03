using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyCheap
{
  public class DreamCountryPopup: MonoBehaviour
  {
    [SerializeField] private SingleImageMap _mapView;

    public void Show(Country country)
    {
			_mapView.ClearMarkers();

      {
        var pos = new Vector2(country.X, country.Y);
        _mapView.AddMarker(pos);
        _mapView.CenterAt(pos);
      }

			gameObject.SetActive(true);
    }
  }
}