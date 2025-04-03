using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyCheap
{
  public interface IControlledWorlMap
  {
		public Vector2 Center { get; }
		//public Vector2 Bounds { get; }

		public void CenterAt (Vector2 pos);

		public void Shift (Vector2 delta);
	}
}