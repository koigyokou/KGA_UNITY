using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Transform camTransform;
    [SerializeField] float camRotateSpeed;

    [SerializeField] int damage;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//Ŀ��(���콺) ȭ�� �߾ӿ� ���� 
    }

    private void Update()
    {
        Move();
        Look();

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(x, 0, z);
        if (moveDir.sqrMagnitude > 1)
        {
            moveDir.Normalize();
        }

        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }

    private void Look()
    {
        float x = Input.GetAxisRaw("Mouse X");
        float y = Input.GetAxisRaw("Mouse Y");

        transform.Rotate(Vector3.up, x * camRotateSpeed * Time.deltaTime);
        camTransform.Rotate(Vector3.right, -y * camRotateSpeed * Time.deltaTime);
    }

    private void Fire()
    {
        if (Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit hit)) // ����ĳ��Ʈ ī�޶� ��ġ��, �չ�������, ���������� �¾Ҵٸ�
        {
            Monster monster = hit.collider.GetComponent<Monster>();
            if (monster != null)
            {
                monster.TakeHit(damage);//���� ������ �ǰ�
            }
        }
    }
}
