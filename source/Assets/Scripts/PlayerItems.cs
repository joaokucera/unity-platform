using UnityEngine;
using System.Collections;

public class PlayerItems : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Coin")
		{
			HUDManager.Instance.TakeCoin(collider.GetComponent<Coin>().coinType);

			Destroy(collider.gameObject);
		}
	}
}
