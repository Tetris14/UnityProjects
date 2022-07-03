using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private LayerMask groundMask;

    public bool isGrounded;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("terrain"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        isGrounded = false;
    }
}
