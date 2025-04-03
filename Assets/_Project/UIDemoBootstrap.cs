using UnityEngine;

using FlyCheap.UI;
using System;

namespace FlyCheap
{
	public class UIDemoBootstrap: MonoBehaviour
	{
		[SerializeField] private CountriesList _countriesList;
		[SerializeField] private FrameCountriesList _frameCountriesList;
		[SerializeField] private FrameCountryPopup _frameCountryDetails;
		[SerializeField] private FrameWorldMap _frameWorldMap;

		private void Awake ()
		{
			_frameCountriesList.SetCountriesList(_countriesList);

			_frameCountriesList.OnCountrySelected += CloseListOpenDetails;
			_frameCountryDetails.OnClickedOpen += OpenWorldMap;
			_frameWorldMap.OnClosed += () => SwitchFrames(_frameWorldMap, _frameCountryDetails);
			_frameCountryDetails.OnClosed += () => SwitchFrames(_frameCountryDetails, _frameCountriesList);

			_frameCountriesList.gameObject.SetActive(true);
			_frameCountryDetails.gameObject.SetActive(false);
		}

		private void SwitchFrames (FrameSceneObject from, FrameSceneObject to)
		{
			from.HideFrame();
			to.ShowFrame();
		}

		private void CloseListOpenDetails (Country country)
		{
			SwitchFrames(_frameCountriesList, _frameCountryDetails);
			_frameCountryDetails.Show(country);
		}

		private void OpenWorldMap (SingleImageMap map)
		{
			SwitchFrames(_frameCountryDetails, _frameWorldMap);
			_frameWorldMap.GetMapView().CopyInfoFromMap(map);
		}
	}
}