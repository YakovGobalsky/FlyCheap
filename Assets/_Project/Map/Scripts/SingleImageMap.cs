using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyCheap
{
	public class SingleImageMap: MapView<MarkerImage>
	{
		//[SerializeField] private Vector2 _markersPosScale = new Vector2(2048f/180f / 2, 1024/180f / 2);
		[SerializeField] private Vector2 _mapImageSize = new Vector2(2048f, 1024f);
		[SerializeField] private RectTransform _map;
		[SerializeField] private MarkerImage _markerPrefab;
		[SerializeField] private Transform _markersHolder;

		public override void CenterAt (Vector2 pos)
		{
			Vector2 lc;
			lc.x = -(pos.x - _mapImageSize.x / 2f) * _map.localScale.x;
			lc.y = (pos.y - _mapImageSize.y / 2f) * _map.localScale.y;
			Center = lc;
			UpdateViewPos();
		}

		public override void Shift (Vector2 delta)
		{
			base.Shift(delta);
			UpdateViewPos();
		}

		private void UpdateViewPos ()
		{
			_map.localPosition = Center;
		}

		private Vector2 CalcMarkerPosition (Vector2 pos)
		{
			return new Vector2(pos.x / _mapImageSize.x, +1f - pos.y / _mapImageSize.y);
		}

		protected override MarkerImage CreateMarkerImpl (Vector2 pos)
		{
			var marker = GameObject.Instantiate(_markerPrefab, _markersHolder);
			//marker.transform.localPosition = CalcMarkerPosition(pos);
			var anchor = CalcMarkerPosition(pos);
			var rct = marker.transform as RectTransform;
			rct.anchorMin = anchor;
			rct.anchorMax = anchor;

			return marker;
		}
	}
}