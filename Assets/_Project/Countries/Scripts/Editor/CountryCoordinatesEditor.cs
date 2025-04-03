using UnityEngine;
using UnityEditor;

namespace FlyCheap
{
	public class CountryCoordinatesEditor: EditorWindow
	{
		private Texture _curTexture;
		private Country _curCountry = null;

		[MenuItem("FlyCheap/CountryCoordinatesEditor")]
		public static void Init ()
		{
			var window = GetWindow<CountryCoordinatesEditor>("CountryCoordinatesEditor");
			window.Show();
		}

		private void OnEnable ()
		{
			//_marker = Resources.Load<Texture>("");
		}

		//private void CreateGUI ()
		//{
		//	rootVisualElement.pickingMode = PickingMode.Position;
		//	rootVisualElement.RegisterCallback<PointerDownEvent>(LogPointer);
		//}

		//private void LogPointer (PointerDownEvent evt)
		//{
		//	if (_curCountry && _curTexture)
		//	{
		//		var dx = evt.position.x / position.width;
		//		var dy = evt.position.y / position.height;
		//		//Debug.Log($"Pointer Position: {evt.position} / {position.width},{position.height}. {dx * _curTexture.width},{dy * _curTexture.height}");
		//		_curCountry.SetXY(dx * _curTexture.width, dy * _curTexture.height);
		//		Repaint();
		//	}
		//}

		private void OnGUI ()
		{
			if (_curTexture && _curCountry)
			{
				if (Event.current.type == EventType.MouseDown)
				{
					var dx = Event.current.mousePosition.x / position.width;
					var dy = Event.current.mousePosition.y / position.height;
					//Debug.Log($"Pointer Position: {Event.current.mousePosition} / {position.width},{position.height}. {dx * _curTexture.width},{dy * _curTexture.height}");
					_curCountry.SetXY(dx * _curTexture.width, dy * _curTexture.height);
					Repaint();
				}
			}

			{
				//_curCountry && _curCountry.EditorOnlyImage
				if (_curTexture)
				{
					EditorGUI.DrawTextureTransparent(new Rect(0, 0, position.width, position.height), _curTexture, ScaleMode.StretchToFill);

					if (_curCountry)
					{
						//EditorGUI.DrawTextureTransparent(new Rect(0, 0, position.width, position.height), _marker, ScaleMode.ScaleToFit);
						var pos = new Vector2(_curCountry.X / _curTexture.width, _curCountry.Y / _curTexture.height);
						EditorGUI.DrawRect(new Rect(pos.x * position.width, 0, 1, position.height), Color.magenta);
						EditorGUI.DrawRect(new Rect(0, pos.y * position.height, position.width, 1), Color.magenta);
					}
				}
				_curTexture = EditorGUILayout.ObjectField(_curTexture, typeof(Texture), false) as Texture;
				//EditorGUI.On
			}
		}

		private void OnSelectionChange ()
		{
			if (Selection.activeObject)
			{
				if (Selection.activeObject is Country)
				{
					_curCountry = (Country)Selection.activeObject;
					Repaint();
					return;
				}
			}

			if (_curCountry != null)
			{
				_curCountry = null;
				Repaint();
			}
		}
	}
}