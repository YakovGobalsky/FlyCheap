using UnityEngine;

using DG.Tweening;

namespace FlyCheap
{
  [RequireComponent(typeof(CanvasGroup))]
  public class FrameSceneObject: MonoBehaviour
  {
    [SerializeField] private CanvasGroup _canvasGroup;

		private Tween _animation = null;

		public event System.Action OnClosed;

		private void OnValidate ()
		{
			_canvasGroup = GetComponent<CanvasGroup>();
		}

		protected virtual void OnDisable ()
		{
			TryStopAnimation();
		}

		public CanvasGroup Canvas => _canvasGroup;

		public void CloseFrame() => OnClosed?.Invoke();

		public void ShowFrame ()
		{
			TryStopAnimation();
			gameObject.SetActive(true);
			_canvasGroup.interactable = false;
			_animation = _canvasGroup.DOFade(1f, 0.2f).OnComplete(() =>
			{
				_canvasGroup.interactable = true;
			});
		}

		public void HideFrame()
		{
			TryStopAnimation();
			_canvasGroup.interactable = false;
			_animation = _canvasGroup.DOFade(0f, 0.2f).OnComplete(() =>
			{
				gameObject.SetActive(false);
			});
		}

		private void TryStopAnimation()
		{
			_animation?.Kill();
			_animation = null;
		}
	}
}