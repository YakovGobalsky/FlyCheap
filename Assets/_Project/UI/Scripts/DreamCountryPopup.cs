using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyCheap
{
  public class DreamCountryPopup: MonoBehaviour
  {
		[SerializeField] private SingleImageMap _mapView;
		[SerializeField] private SingleImageMap _mapDetailedView;

		public void Show(Country country)
    {
			_mapView.ClearMarkers();
			gameObject.SetActive(true);

			{
				var pos = new Vector2(country.X, country.Y);
        _mapView.AddMarker(pos);
        _mapView.CenterAt(pos);

				_mapDetailedView.AddMarker(pos);
				_mapDetailedView.CenterAt(pos);
			}
		}
  }
}