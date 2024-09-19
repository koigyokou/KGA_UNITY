using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] Bullet[] bulletPrefab;//탄환 여러가지를 쓰기위한 배열 선언
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
        curBulletPrefab = bulletPrefab[0]; //처음 프리팹을 적용
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

        transform.Translate(Vector3.forward * z * moveSpeed * Time.deltaTime);//베터포워드 방향에 z축 값을 곱해서 이동을 구현
        transform.Rotate(Vector3.up, x * rotateSpeed * Time.deltaTime);//회전의 경우에는 x축을 활용(제자리에서 돔)
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

        yAimAngle = Mathf.Clamp(yAimAngle + y * aimRotateSpeed * Time.deltaTime, -maxAimRotate, maxAimRotate);//clamp를 결정하는 값은 현재각,최소치,최대치
        xAimAngle = Mathf.Clamp(xAimAngle - x * aimRotateSpeed * Time.deltaTime, -maxAimRotate, 0);

        turretTransform.localRotation = Quaternion.Euler(xAimAngle, yAimAngle, 0);//쿼터니언으로 x축 y축 회전
    }

    private void Fire()
    {
        Instantiate(curBulletPrefab, muzzlePoint.position, muzzlePoint.rotation);//생성 : 현재 총알, muzzlepoint위치에, muzzlepoint 회전값에
    }

    private void SwapBullet(int index)
    {
        curBulletPrefab = bulletPrefab[index];//배열인덱스에 따라 프리팹 전환
    }
}
