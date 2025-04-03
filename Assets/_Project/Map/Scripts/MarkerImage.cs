using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyCheap
{
	public class MarkerImage: MonoBehaviour, IMarker
	{
		public void DestroyMarker ()
		{
			Destroy(gameObject);
		}
	}
}