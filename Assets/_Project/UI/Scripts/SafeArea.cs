using UnityEngine;

namespace FlyCheap.UI
{
	//https://docs.unity3d.com/ScriptReference/Screen-safeArea.html
	public class SafeArea: MonoBehaviour
  {
		private RectTransform _rectTransform;
		private Rect _curSafeArea = new(0, 0, 0, 0);

		private void Awake ()
		{
			_rectTransform = GetComponent<RectTransform>();
		}

		private void Update ()
		{
			CheckSafeAreaChanges();
		}

		private void CheckSafeAreaChanges ()
		{
			Rect safeArea = Screen.safeArea;

			if (safeArea != _curSafeArea)
			{
				_curSafeArea = safeArea;
				UpdateTransform(_curSafeArea);
			}
		}

		private void UpdateTransform (Rect safeArea)
		{
			var anchorMin = safeArea.position;
			var anchorMax = safeArea.position + safeArea.size;
			anchorMin.x /= Screen.width;
			anchorMin.y /= Screen.height;
			anchorMax.x /= Screen.width;
			anchorMax.y /= Screen.height;
			_rectTransform.anchorMin = anchorMin;
			_rectTransform.anchorMax = anchorMax;
		}
	}
}