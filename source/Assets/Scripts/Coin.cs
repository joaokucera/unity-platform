using UnityEngine;
using System.Collections;

public enum CoinType
{
	Bronze = 1,
	Silver = 2,
	Gold = 3
}

public class Coin : MonoBehaviour {

	public CoinType coinType = CoinType.Bronze;
}
