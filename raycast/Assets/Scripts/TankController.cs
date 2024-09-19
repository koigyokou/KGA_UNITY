using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] Bullet[] bulletPrefab;//źȯ ���������� �������� �迭 ����
    [SerializeField] Transform muzzlePoint;
    [SerializeField] Transform turretTransform;

    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;

    [SerializeField] float aimRotateSpeed;
    [SerializeField] float maxAimRotate;

    private Bullet curBulletPrefab;
    private float yAimAngle;
    private float xAimAngle;

    private void Awake()
    {
        curBulletPrefab = bulletPrefab[0]; //ó�� �������� ����
    }

    private void Update()
    {
        Move();
        Aim();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwapBullet(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwapBullet(1);
        }
    }

    private void Move()
    {
        float x = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            x -= 1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            x += 1;
        }

        float z = 0;
        if (Input.GetKey(KeyCode.DownArrow))
        {
            z -= 1;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            z += 1;
        }

        transform.Translate(Vector3.forward * z * moveSpeed * Time.deltaTime);//���������� ���⿡ z�� ���� ���ؼ� �̵��� ����
        transform.Rotate(Vector3.up, x * rotateSpeed * Time.deltaTime);//ȸ���� ��쿡�� x���� Ȱ��(���ڸ����� ��)
    }

    private void Aim()
    {
        float y = 0;
        if (Input.GetKey(KeyCode.A))
        {
            y -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            y += 1;
        }

        float x = 0;
        if (Input.GetKey(KeyCode.S))
        {
            x -= 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            x += 1;
        }

        yAimAngle = Mathf.Clamp(yAimAngle + y * aimRotateSpeed * Time.deltaTime, -maxAimRotate, maxAimRotate);//clamp�� �����ϴ� ���� ���簢,�ּ�ġ,�ִ�ġ
        xAimAngle = Mathf.Clamp(xAimAngle - x * aimRotateSpeed * Time.deltaTime, -maxAimRotate, 0);

        turretTransform.localRotation = Quaternion.Euler(xAimAngle, yAimAngle, 0);//���ʹϾ����� x�� y�� ȸ��
    }

    private void Fire()
    {
        Instantiate(curBulletPrefab, muzzlePoint.position, muzzlePoint.rotation);//���� : ���� �Ѿ�, muzzlepoint��ġ��, muzzlepoint ȸ������
    }

    private void SwapBullet(int index)
    {
        curBulletPrefab = bulletPrefab[index];//�迭�ε����� ���� ������ ��ȯ
    }
}
