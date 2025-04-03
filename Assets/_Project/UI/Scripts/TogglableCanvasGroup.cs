using UnityEngine;

using DG.Tweening;

namespace FlyCheap.UI
{
	public class TogglableCanvasGroup: MonoBehaviour
	{
		[SerializeField] private CanvasGroup _canvasGroup;

		private Sequence _sequence = null;

		private bool _isVisible = false;

		private float GetAlpha (bool targetState) => targetState ? 1 : 0;

		private void OnDisable ()
		{
			TryStopAnimation();
		}

		public void Toggle ()
		{
			_canvasGroup.gameObject.SetActive(true);

			TryStopAnimation();
			//InstantUpdateState();
			_isVisible = !_isVisible;

			_canvasGroup.interactable = false;
			_canvasGroup.alpha = GetAlpha(!_isVisible);

			_sequence = DOTween.Sequence();
			_sequence.Append(_canvasGroup.DOFade(GetAlpha(_isVisible), 0.2f));
			//_sequence.Join(_canvasGroup.transform.DOScale(GetScale(_isVisible), 1f));

			if (_isVisible)
			{
				_sequence.OnComplete(() =>
				{
					_canvasGroup.interactable = true;
				});
			}
			else
			{
				_sequence.OnComplete(() =>
				{
					_canvasGroup.interactable = false;
					_canvasGroup.gameObject.SetActive(false);
				});
			}

			_sequence.Play();
		}

		private void TryStopAnimation ()
		{
			_sequence?.Kill(true);
			_sequence = null;
		}
	}
}