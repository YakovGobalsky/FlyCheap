using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace FlyCheap
{
  [CreateAssetMenu(menuName = "Countries/Country")]
  public class Country: ScriptableObject
  {
		[field: SerializeField] public string Title { get; private set; }
		[field: SerializeField] public Sprite Icon { get; private set; }

		[field: SerializeField] public float X { get; private set; }
		[field: SerializeField] public float Y { get; private set; }

#if UNITY_EDITOR
		public Sprite EditorOnlyImage;

		public void SetXY(float x, float y)
		{
			X = x;
			Y = y;
			EditorUtility.SetDirty(this);
		}
#endif
	}
}