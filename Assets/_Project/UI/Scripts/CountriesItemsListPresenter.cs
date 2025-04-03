using System.Collections.Generic;
using UnityEngine;

namespace FlyCheap.UI
{
  public class CountriesItemsListPresenter: MonoBehaviour
  {
		[SerializeField] private CountriesButton _btnPrefab;
		[SerializeField] private Transform _itemsHolder;

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
				OnCountrySelected?.Invoke(button.Country);
			}
		}
	}
}