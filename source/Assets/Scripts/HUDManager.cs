using UnityEngine;
using System.Collections;

public class HUDManager : MonoBehaviour {

	public static HUDManager Instance;

	public GUIText coinBronzeTextHUD;
	public GUIText coinSilverTextHUD;
	public GUIText coinGoldTextHUD;

	private int coinBronzeAmount = 0;
	private int coinSilverAmount = 0;
	private int coinGoldAmount = 0;
	
	public GUIText timerTextHUD;
	private const float StartTimerLevel = 59;

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
	}

	void Start()
	{
		StartCoroutine (TimerCountdown ());
	}

	void Update () {

		coinBronzeTextHUD.text = coinBronzeAmount.ToString ();
		coinSilverTextHUD.text = coinSilverAmount.ToString ();
		coinGoldTextHUD.text = coinGoldAmount.ToString ();
	}

	IEnumerator TimerCountdown ()
	{
		for (float timerLevel = StartTimerLevel; timerLevel >= 0; timerLevel -= Time.deltaTime) {

			timerTextHUD.text = timerLevel.ToString ("00:00");

			yield return 0;	
		}

		timerTextHUD.text = "GAME OVER";
	}

	public void TakeCoin (CoinType coinType)
	{
		//coinBronzeAmount += (int)coinType;

		switch (coinType) 
		{
			case CoinType.Gold:
				coinGoldAmount++;
				break;

			case CoinType.Silver:
				coinSilverAmount++;
				break;

			case CoinType.Bronze:
			default:	
				coinBronzeAmount++;
				break;
		}
	}
}
