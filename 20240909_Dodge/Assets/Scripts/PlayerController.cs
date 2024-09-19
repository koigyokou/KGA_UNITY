using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Rigidbody rigidPlayer;
    [SerializeField] float moveSpeed;

    public event Action OnDied;

    private void Update()
    {
        Move(); // ���� �Լ� ������Ʈ���� ��� ����
    }

    private void Move()
    {
        // �Է½ý��ۿ��� ����Ǿ� ����
        float x = Input.GetAxisRaw("Horizontal"); // �¿�
        float z = Input.GetAxisRaw("Vertical"); // ����

        Vector3 moveDir = new Vector3(x, 0, z); // ����𷺼� ������ x z �� ��������
        if (moveDir.sqrMagnitude > 1)  // magnitude : ������ ũ�� / sqrMagnitude : ������ ũ���� ����, ��Ʈ ����� �������� ����(����ȭ�� �� ����)
        {
            moveDir.Normalize(); // ������ 1�� ������ : ���������� �Ÿ��� 1�̻��̸� // ����ȭ ����
        }

        rigidPlayer.velocity = moveDir * moveSpeed; // �ӵ��� ����𷺼� ���ϱ� ���꽺�ǵ�
    }

    public void TakeHit()
    {
        OnDied?.Invoke(); // �´��̵� �̺�Ʈ? ȣ��
        Destroy(gameObject); // ������Ʈ ����
    }
}
