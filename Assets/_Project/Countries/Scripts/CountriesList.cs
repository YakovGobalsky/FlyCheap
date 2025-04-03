using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyCheap
{
  [CreateAssetMenu(menuName = "Countries/Countries list")]
  public class CountriesList: ScriptableObject, IEnumerable<Country>
	{
    [SerializeField] private Country[] _countries;

    public IEnumerable<Country> Countries => _countries;

		public IEnumerator<Country> GetEnumerator () => Countries.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator () => Countries.GetEnumerator ();
	}
}