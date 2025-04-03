using UnityEngine;
using UnityEngine.EventSystems;

namespace FlyCheap
{
	public class MapDragArea: MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		[SerializeField] private int _fingerId = 0;

		public event System.Action<PointerEventData> onDragBegin;
		public event System.Action<PointerEventData> onDrag;
		public event System.Action<PointerEventData> onDragEnd;

		public void OnBeginDrag (PointerEventData eventData)
		{
#if !UNITY_EDITOR && !UNITY_STANDALONE_WIN
			if (_fingerId >= 0 && eventData.pointerId != _fingerId) {
				return;
			}
#endif
			onDragBegin?.Invoke(eventData);
		}

		public void OnDrag (PointerEventData eventData)
		{
#if !UNITY_EDITOR && !UNITY_STANDALONE_WIN
			if (_fingerId >= 0 && eventData.pointerId != _fingerId) {
				return;
			}
#endif
			onDrag?.Invoke(eventData);
		}

		public void OnEndDrag (PointerEventData eventData)
		{
#if !UNITY_EDITOR && !UNITY_STANDALONE_WIN
			if (_fingerId >= 0 && eventData.pointerId != _fingerId) {
				return;
			}
#endif
			onDragEnd?.Invoke(eventData);
		}
	}
}