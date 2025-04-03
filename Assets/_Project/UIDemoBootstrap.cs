using UnityEngine;

using FlyCheap.UI;

namespace FlyCheap
{
  public class UIDemoBootstrap: MonoBehaviour
  {
		[SerializeField] private CountriesList _countriesList;
		[SerializeField] private CountriesItemsListPresenter _countriesView;
		[SerializeField] private DreamCountryPopup _countryDetails;

		private void Awake ()
		{
			_countriesView.SetCountriesList(_countriesList);
			_countriesView.OnCountrySelected += (country) =>
			{
				_countriesView.gameObject.SetActive(false);
				_countryDetails.Show(country);
			};

			_countriesView.gameObject.SetActive(true);
			_countryDetails.gameObject.SetActive(false);
		}
	}
}