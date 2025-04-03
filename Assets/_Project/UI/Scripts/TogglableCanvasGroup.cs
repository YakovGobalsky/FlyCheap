using UnityEngine;

using DG.Tweening;

namespace FlyCheap.UI
{
	[RequireComponent(typeof(CanvasGroup))]
	public class TogglableCanvasGroup: MonoBehaviour
	{
		[SerializeField] private bool _defaultState = false;

		private Sequence _sequence = null;

		private CanvasGroup _canvasGroup;

		private bool _isVisible = false;

		private float GetAlpha (bool targetState) => targetState ? 1 : 0;
		private Vector3 GetScale (bool targetState) => targetState ? Vector3.one : Vector3.one / 10f;

		private void Awake ()
		{
			_canvasGroup = GetComponent<CanvasGroup>();
			_isVisible = _defaultState;
		}

		private void OnEnable ()
		{
			InstantUpdateState();
		}

		private void OnDisable ()
		{
			TryStopAnimation();
		}

		public void Toggle ()
		{
			TryStopAnimation();
			//InstantUpdateState();
			_isVisible = !_isVisible;

			_sequence = DOTween.Sequence();
			_sequence.Append(_canvasGroup.DOFade(GetAlpha(_isVisible), 1f));
			_sequence.Join(_canvasGroup.transform.DOScale(GetScale(_isVisible), 1f));
			_sequence.Play();
		}

		private void TryStopAnimation ()
		{
			_sequence?.Kill(true);
			_sequence = null;
		}

		private void InstantUpdateState ()
		{
			_canvasGroup.alpha = GetAlpha(_isVisible);
			transform.localScale = GetScale(_isVisible);
		}
	}
}