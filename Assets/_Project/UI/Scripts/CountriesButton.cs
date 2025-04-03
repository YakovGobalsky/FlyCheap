using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FlyCheap
{
  public class CountriesButton: MonoBehaviour
  {
		[SerializeField] private Button _button;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _title;
    [SerializeField] private GameObject _stateSelected;

		public bool IsChecked { get; private set; } = false;

		public Country Country { get; private set; }

		public System.Action<CountriesButton> OnClicked;

		public void Init(Country country)
		{
			Country = country;
			_button.onClick.AddListener(() =>
			{
				IsChecked = !IsChecked;
				OnClicked?.Invoke(this);
			});
			Refresh();
		}

		private void Refresh()
		{
			_icon.sprite = Country.Icon;
			_title.text = Country.Title;

			_stateSelected.SetActive(IsChecked);
		}
	}
}