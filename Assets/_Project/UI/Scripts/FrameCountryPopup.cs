using UnityEngine;

namespace FlyCheap
{
  public class FrameCountryPopup: FrameSceneObject
	{
		[SerializeField] private SingleImageMap _mapView;

		public System.Action<SingleImageMap> OnClickedOpen;

		public void Show(Country country)
    {
			_mapView.ClearMarkers();

			{
				var pos = new Vector2(country.X, country.Y);
        _mapView.AddMarker(pos);
        _mapView.CenterAt(pos);
			}
		}

		public void OpenDetails()
		{
			OnClickedOpen?.Invoke(_mapView);
		}
  }
}