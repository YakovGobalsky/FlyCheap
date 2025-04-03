using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlyCheap
{
	public class Preloader: MonoBehaviour
	{
		[SerializeField] private Transform _progressIndicator;

		private IEnumerator Start ()
		{
			UpdateProgress(0f);
			DOTween.Init();

			yield return null;

			bool isLoaded = false;
			AsyncOperation loadingOperation = SceneManager.LoadSceneAsync("game");
			loadingOperation.allowSceneActivation = false;
			while (!loadingOperation.isDone)
			{
				UpdateProgress(loadingOperation.progress);

				//https://docs.unity3d.com/ScriptReference/AsyncOperation-allowSceneActivation.html
				if (loadingOperation.progress >= 0.9f)
				{
					if (!isLoaded)
					{
						isLoaded = true;
						loadingOperation.allowSceneActivation = true;
					}
				}
				yield return null;
			}
		}

		private void UpdateProgress (float progress)
		{
			_progressIndicator.transform.localEulerAngles = new Vector3(0, 0, progress * 720f);
		}
	}
}