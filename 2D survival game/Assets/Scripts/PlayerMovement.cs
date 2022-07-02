using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float movSpeed = 6;
	public float jumpForce = 20;

	public Rigidbody2D rb;
	public Animator anim;

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

		// if mov is > 0 then rotate the player to the right else rotate the player to the left
		if (mov > 0)
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
		}
		else if (mov < 0)
		{
			transform.eulerAngles = new Vector3(0, 180, 0);
		}

		if(Input.GetButtonDown("Jump"))
		{
			rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
			anim.SetBool("isJumping", true);
		}
	}
}