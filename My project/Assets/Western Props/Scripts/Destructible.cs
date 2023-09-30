using UnityEngine;

public class Destructible : MonoBehaviour 
{
	[SerializeField] private GameObject _destroyedVersion;

	public void Destruct()
	{
		Instantiate(_destroyedVersion, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
