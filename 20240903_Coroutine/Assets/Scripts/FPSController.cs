using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [Header("Mover")]
    [SerializeField] float moveSpeed;
    [SerializeField] Transform camTransform;
    [SerializeField] float camRotateSpeed;

    [Header("Shooter")]
    [SerializeField] int maxBullet;
    [SerializeField] int curBullet;
    [SerializeField] float repeatTime;
    [SerializeField] float reloadTime;
    [SerializeField] bool isReloading;
    [SerializeField] int damage;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // (���콺)Ŀ�� �߾ӿ� ���� 
    }

    private void Update()
    {
        Move();
        Look();

        if (Input.GetButtonDown("Fire1"))
        {
            fireRepeatRoutine = StartCoroutine(FireRepeatRoutine());//��Ŭ���� �ڷ�ƾ ���� ----- �ڷ�ƾ ����?�� �־������
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fireRepeatRoutine); // �ڷ�ƾ ���� ----- ��ž�ڷ�ƾ�� �ϴ°� �ƴ϶� �ڷ�ƾ ����?�� ���������
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();// rŰ�� ������
        }
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(x, 0, z); // �����¿� ���������� ����
        if (moveDir.sqrMagnitude > 1)
        {
            moveDir.Normalize();// ���� ��ֶ�����
        }

        transform.Translate(moveDir * moveSpeed * Time.deltaTime); // ��ġ�̵��� translate�� ����
    }

    private void Look()
    {
        float x = Input.GetAxisRaw("Mouse X");
        float y = Input.GetAxisRaw("Mouse Y");

        transform.Rotate(Vector3.up, x * camRotateSpeed * Time.deltaTime); // ���� �� �������� ���콺 �����Ӵ��
        camTransform.Rotate(Vector3.right, -y * camRotateSpeed * Time.deltaTime);// ���� ����Ʈ �������� ���콺 �����Ӵ��
    }

    Coroutine fireRepeatRoutine;// �ڷ�ƾ ����
    IEnumerator FireRepeatRoutine()// �ڷ�ƾ ����
    {
        WaitForSeconds delay = new WaitForSeconds(repeatTime); // ����ƮŸ�Ӹ�ŭ ��ٸ�_1

        while (true)
        {
            Fire();
            yield return delay;// ����ƮŸ�Ӹ�ŭ ��ٸ�_2
        }
    }

    private void Reload()
    {
        if (isReloading) // ������ ���̶�� �Լ� ����
            return;

        StartCoroutine(ReloadRoutine()); // ȣ��� ������ �ڷ�ƾ ����
    }

    IEnumerator ReloadRoutine()// ������ �ڷ�ƾ ����
    {
        Debug.Log("������ ����!");
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        curBullet = maxBullet;
        isReloading = false;
        Debug.Log("������ �Ϸ�!");
    }

    private void Fire()
    {
        if (curBullet <= 0)// ���� �Ѿ��� 0�����̸� ź�˺��� ��� / �Լ� ����
        {
            Debug.Log("ź�� ����!");
            return;
        }

        if (isReloading == true)// ������ ���̶�� ������ ��... ��� / �Լ� ����
        {
            Debug.Log("������ ��...");
            return;
        }

        curBullet--; // �Լ� ȣ��� �ϳ��� �Ѿ� ���̱�
        Debug.Log($"Fire {curBullet} / {maxBullet}");//���� �Ѿ� ���
        if (Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit hit)) // ����ĳ��Ʈ (ī�޶���ġ����, �չ�������, )�¾Ҵٸ�
        {
            Monster monster = hit.collider.GetComponent<Monster>();
            if (monster != null)
            {
                monster.TakeHit(damage); // ���� �ǰ�(��������ŭ)
            }
        }
    }
}
