using UnityEngine;
using System.Collections;

public class ShotMovement : MonoBehaviour {

	public float speed = 5f;
	[HideInInspector]
	public FacingSide facing = FacingSide.RIGHT;

	private Renderer childRenderer;

	void Start()
	{
		childRenderer = GetComponentInChildren<SpriteRenderer> ();
	}

	void Update () 
	{
		if (!childRenderer.isVisible)
		{
			gameObject.SetActive(false);
		}

		if (facing == FacingSide.RIGHT)
		{
			transform.Translate (new Vector2 (speed * Time.deltaTime, 0));
		}
		else
		{
			transform.Translate (new Vector2 (-speed * Time.deltaTime, 0));
		}
	}
}
