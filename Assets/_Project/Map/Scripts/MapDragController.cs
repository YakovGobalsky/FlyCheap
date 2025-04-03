using UnityEngine;
using UnityEngine.EventSystems;

namespace FlyCheap
{
	[RequireComponent(typeof(IControlledWorlMap))]
	public class MapDragController: MonoBehaviour
	{
		[SerializeField] private MapDragArea _dragArea;
		[SerializeField] private IControlledWorlMap _map;

		private Vector2 _dragStartPos;

		private void Awake ()
		{
			_map = GetComponent<IControlledWorlMap>();
		}

		private void OnEnable ()
		{
			_dragArea.onDragBegin += OnDragBegin;
			_dragArea.onDrag += OnDrag;
			_dragArea.onDragEnd += OnDragEnd;
		}

		private void OnDisable ()
		{
			_dragArea.onDragBegin += OnDragBegin;
			_dragArea.onDrag += OnDrag;
			_dragArea.onDragEnd += OnDragEnd;
		}

		private void OnDragBegin (PointerEventData eventData)
		{
			_dragStartPos = GetLocalPosition(eventData);
		}

		private void OnDrag (PointerEventData eventData)
		{
			var pos = GetLocalPosition(eventData);
			_map.Shift(pos - _dragStartPos);
			_dragStartPos = pos;
		}

		private void OnDragEnd (PointerEventData eventData)
		{
		}

		private Vector2 GetLocalPosition (PointerEventData eventData)
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(transform as RectTransform, eventData.position, eventData.pressEventCamera, out var localPos);
			return localPos;
		}
	}
}