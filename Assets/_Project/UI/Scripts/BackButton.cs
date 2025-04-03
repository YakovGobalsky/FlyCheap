using UnityEngine;
using UnityEngine.UI;

namespace FlyCheap
{
	[RequireComponent(typeof(Button))]
	public class BackButton: MonoBehaviour
	{
		[SerializeField] private CanvasGroup _canvasGroup; //not for production/repalce to normal transaction screens

		private Button _button = null;

		private void Awake ()
		{
			_button = GetComponent<Button>();
		}

		private void Update ()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				if (_canvasGroup ? _canvasGroup.interactable : false)
				{
					_button?.onClick?.Invoke();
				}
			}
		}
	}
}