using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 3f;

    private void Update()
    {
        SetPosition();
    }
    private void SetPosition()
    {
        Vector3 direction = GetNormalizedDirection();
        if (direction == Vector3.zero )
        {
            return;
        }

        transform.rotation = Quaternion.LookRotation( direction );
        transform.Translate(moveSpeed  * Time.deltaTime * Vector3.forward);

    }
    private Vector3 GetNormalizedDirection()
    {
        Vector3 inputDirection = Vector3.zero;

        if ( Input.GetKey(KeyCode.W) )
        {
            inputDirection.z += 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputDirection.z -= 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputDirection.x += 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputDirection.x -= 1;
        }

        return inputDirection.normalized;
    }
}
