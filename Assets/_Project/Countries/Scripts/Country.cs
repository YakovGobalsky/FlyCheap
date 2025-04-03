using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyCheap
{
  [CreateAssetMenu(menuName = "Countries/Country")]
  public class Country: ScriptableObject
  {
		[field: SerializeField] public string Title { get; private set; }
		[field: SerializeField] public Sprite Icon { get; private set; }

		[field: SerializeField] public float X { get; private set; }
		[field: SerializeField] public float Y { get; private set; }

	}
}