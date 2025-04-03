using UnityEngine;
using UnityEngine.UI;

namespace FlyCheap
{
  [RequireComponent(typeof(Button))]
  public class BackButton: MonoBehaviour
  {
    private Button _button = null;

		private void Awake ()
		{
			_button = GetComponent<Button>();
		}

		private void Update ()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				_button?.onClick?.Invoke();
			}
		}
	}
}