using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyCheap
{
	public class MarkerImage: MonoBehaviour, IMarker
	{
		public Vector2 Position { get; private set; }

		public void StorePosition(Vector2 position) => Position = position;

		public void DestroyMarker ()
		{
			Destroy(gameObject);
		}
	}
}