using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

namespace FlyCheap
{
  public class FrameCountryPopup: FrameSceneObject
	{
		[SerializeField] private SingleImageMap _mapView;
		[SerializeField] private RectTransform _previewHolder;
		[SerializeField] private GameObject _button;

		public System.Action<SingleImageMap> OnClickedOpen;

		private readonly float _animationTime = 0.5f;
		//private Vector2 _bounds;

		public void Show(Country country)
    {
			_mapView.ClearMarkers();

			{
				var pos = new Vector2(country.X, country.Y);
        _mapView.AddMarker(pos);
        _mapView.CenterAt(pos);
			}
		}

		public void OpenDetails ()
		{
			Canvas.interactable = false;
			_button.gameObject.SetActive(false);

			var sequence = DOTween.Sequence();

			sequence.Append(_previewHolder.DOAnchorMin(new Vector2(-2, -2), _animationTime));
			sequence.Join(_previewHolder.DOAnchorMax(new Vector2(3, 3), _animationTime));

			sequence.OnComplete(() => {
				OnClickedOpen?.Invoke(_mapView);
			});
		}

		public void BackToDetails ()
		{
			Canvas.interactable = false;
			_button.gameObject.SetActive(false);

			var sequence = DOTween.Sequence();

			sequence.Append(_previewHolder.DOAnchorMin(new Vector2(0, 0), _animationTime));
			sequence.Join(_previewHolder.DOAnchorMax(new Vector2(1, 1), _animationTime));

			sequence.OnComplete(() => {
				_button.gameObject.SetActive(true);
				Canvas.interactable = true;
			});
		}
	}
}