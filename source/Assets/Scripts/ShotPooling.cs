using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShotPooling : MonoBehaviour {

	public static ShotPooling Instance;	
	public GameObject shotPrefab;
	public int pooledAmount = 5;
	public bool pooledCanGrow = false;

	private List<GameObject> shots = new List<GameObject>();

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
	}

	void Start () 
	{
		for (int i = 0; i < pooledAmount; i++) 
		{
			CreatePrefab ();
		}
	}

	public GameObject GetShot()
	{
		foreach (GameObject item in shots) 
		{
			if (!item.activeInHierarchy)
			{
				return item;
			}
		}

		if (pooledCanGrow)
		{
			GameObject newShot = CreatePrefab ();

			return newShot;
		}

		return null;
	}

	private GameObject CreatePrefab ()
	{
		GameObject newShot = (GameObject)Instantiate (shotPrefab, transform.position, Quaternion.identity);
		newShot.SetActive (false);

		shots.Add (newShot);

		return newShot;
	}
}
