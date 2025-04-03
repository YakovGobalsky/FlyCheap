using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using static UnityEditor.PlayerSettings;

namespace FlyCheap
{
	public class SingleImageMap: MapView<MarkerImage>, IControlledWorlMap
	{
		//[SerializeField] private Vector2 _markersPosScale = new Vector2(2048f/180f / 2, 1024/180f / 2);
		[SerializeField] private Vector2 _mapImageSize = new Vector2(2048f, 1024f);
		[SerializeField] private RectTransform _map;
		[SerializeField] private MarkerImage _markerPrefab;
		[SerializeField] private Transform _markersHolder;

		//[Header("Bounds")]
		//[SerializeField] private RectTransform _boundsHolder;
		//[SerializeField] private Vector2 _padding;

		public Vector2 _center;

		public Vector2 _boundsMin;
		public Vector2 _boundsMax;

		private void OnEnable ()
		{
			CalculateBounds();
		}

		public void CenterAt (Vector2 pos)
		{
			Vector2 lc;
			lc.x = -(pos.x - _mapImageSize.x / 2f) * _map.localScale.x;
			lc.y = (pos.y - _mapImageSize.y / 2f) * _map.localScale.y;
			_center = lc;
			UpdateViewPos();
		}

		public void Shift (Vector2 delta)
		{
			_center += delta;
			UpdateViewPos();
		}

		private void UpdateViewPos ()
		{
			_center.x = Mathf.Clamp(_center.x, _boundsMin.x, _boundsMax.x);
			_center.y = Mathf.Clamp(_center.y, _boundsMin.y, _boundsMax.y);
			_map.localPosition = _center;
		}

		private Vector2 CalcMarkerPosition (Vector2 pos)
		{
			return new Vector2(pos.x / _mapImageSize.x, 1f - pos.y / _mapImageSize.y);
		}

		protected override MarkerImage CreateMarkerImpl (Vector2 pos)
		{
			var marker = GameObject.Instantiate(_markerPrefab, _markersHolder);
			var anchor = CalcMarkerPosition(pos);
			var rct = marker.transform as RectTransform;
			rct.anchorMin = anchor;
			rct.anchorMax = anchor;

			return marker;
		}

		private void CalculateBounds()
		{
			//var worldBounds = new Vector3[4] { Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero };
			//var localBounds = new Vector3[4] { Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero };
			//_boundsHolder.GetWorldCorners(worldBounds);

			//for (int i=0; i<4; i++)
			//{
			//	localBounds[i] = transform.InverseTransformPoint(worldBounds[i]);
			//}

			//Vector2 offset = new Vector2(localBounds[1].x - localBounds[0].x, localBounds[0].y - localBounds[1].y);

			//_boundsMin = localBounds[1]; //left top
			//_boundsMax = localBounds[3]; //right bottom

			//_boundsMin += offset;
			//_boundsMax -= offset;

			var rctTransform = transform as RectTransform;

			var offset = new Vector2(rctTransform.rect.size.x, rctTransform.rect.size.y) / 2f;

			_boundsMin = new Vector2(-_mapImageSize.x / 2f * _map.localScale.x, -_mapImageSize.y / 2f * _map.localScale.y) + offset;
			_boundsMax = new Vector2(+_mapImageSize.x / 2f * _map.localScale.x, +_mapImageSize.y / 2f * _map.localScale.y) - offset;
		}
	}
}