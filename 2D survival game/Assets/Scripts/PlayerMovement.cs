using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float movSpeed = 6;
	public float jumpForce = 20;

	public Rigidbody2D rb;
	public Animator anim;
	public GroundCheck groundCheck;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		var mov = Input.GetAxis("Horizontal");
		transform.position += new Vector3(mov, 0, 0) * Time.deltaTime *  movSpeed;
		Debug.Log(mov);	

		anim.SetFloat("playerSpeed", Mathf.Abs(mov));

		if (mov > 0)
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
		}
		else if (mov < 0)
		{
			transform.eulerAngles = new Vector3(0, 180, 0);
		}

		if(IsGrounded() && Input.GetButtonDown("Jump"))
		{
			rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
			anim.SetBool("isJumping", true);
		}
		if (IsGrounded())
		{
			anim.SetBool("isJumping", false);
		} else if (!IsGrounded())
		{
			anim.SetBool("isJumping", true);
		}
	}

	private bool IsGrounded()
	{
		return groundCheck.isGrounded;
	}
}