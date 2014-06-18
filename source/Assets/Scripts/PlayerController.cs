using UnityEngine;
using System.Collections;

public enum FacingSide
{
	LEFT,
	RIGHT
}

public class PlayerController : MonoBehaviour {

	public float hMaxSpeed = 10f;
	public float vMaxSpeed = 10f;
	public Transform groundCheck;
	public LayerMask groundLayerMask;
	public Transform shotAim;
	
	private FacingSide facing = FacingSide.RIGHT;
	private Animator animator;
	private bool grounded = false;
	private float groundRadius = 0.2f;

	private float shotCountdown = 0;
	private const float shotCountdownTime = 0.2f;

	void Start()
	{
		animator = GetComponent<Animator> ();
	}

	void Update()
	{
		if (Input.GetButtonDown("Jump"))
		{
			animator.SetBool("ground", false);
			rigidbody2D.AddForce(new Vector2(0, vMaxSpeed));
		}

		animator.SetBool("shoot", Input.GetButton("Fire1"));

		if (shotCountdown <= 0 && Input.GetButton("Fire1"))
		{
			shotCountdown = shotCountdownTime;

			GameObject newShot =  ShotPooling.Instance.GetShot();
			if (newShot != null) 
			{
				newShot.GetComponent<ShotMovement>().facing = facing;
				newShot.transform.position = shotAim.position;
				newShot.SetActive(true);
			}
		}

		shotCountdown -= Time.deltaTime;
	}

	void FixedUpdate()
	{
		// Verificando se o jogador está sobre algum chão.
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, groundLayerMask);
		animator.SetBool ("ground", grounded);

		// Pegando a movimentação.
		float movement = Input.GetAxis ("Horizontal");

		// Setando para o animator o valor da movimentação.
		animator.SetFloat ("hSpeed", Mathf.Abs (movement));

		// Setando para o animator o valor do pulo.
		animator.SetFloat ("vSpeed", rigidbody2D.velocity.y);

		// Realizando a movimentação.
		rigidbody2D.velocity = new Vector2 (movement * hMaxSpeed, rigidbody2D.velocity.y);

		if (movement > 0 && facing == FacingSide.LEFT)
		{
			facing = FacingSide.RIGHT;
			Flip();
		}
		else if (movement < 0 && facing == FacingSide.RIGHT)
		{
			facing = FacingSide.LEFT;
			Flip();
		}
	}

	void Flip ()
	{
		transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}
}
