using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FlyCheap.UI
{
  public class FrameCountriesList: FrameSceneObject
	{
		[SerializeField] private CountriesButton _btnPrefab;
		[SerializeField] private Transform _itemsHolder;
		[SerializeField] private TogglableCanvasGroup _itemsListGroup;

		private CountriesList _countriesList;

		public System.Action<Country> OnCountrySelected;

		private List<CountriesButton> _items = new ();

		public void SetCountriesList(CountriesList countriesList)
		{
			_countriesList = countriesList;
		}

		private void OnEnable ()
		{
			RefreshList();
		}

		public void ToggleGroup () => _itemsListGroup.Toggle();

		private void RefreshList ()
		{
			foreach (var item in _items)
			{
				Destroy(item.gameObject);
			}
			_items.Clear();

			foreach (var country in _countriesList)
			{
				var btn = GameObject.Instantiate(_btnPrefab, _itemsHolder);
				btn.Init(country);

				btn.OnClicked += OnCountryClicked;
				_items.Add(btn);
			}
		}

		private void OnCountryClicked (CountriesButton button)
		{
			if (button.IsChecked)
			{
				Canvas.interactable = false;
				StartCoroutine(WaitAndCastAction(button));
			}
		}

		private IEnumerator WaitAndCastAction(CountriesButton button)
		{
			ToggleGroup();
			yield return new WaitForSecondsRealtime(1f);
			OnCountrySelected?.Invoke(button.Country);
		}
	}
}