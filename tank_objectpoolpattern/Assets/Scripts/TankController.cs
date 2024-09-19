using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] ObjectPool[] bulletPool;
    private ObjectPool curBulletPool;

    [SerializeField] Transform muzzlePoint;

    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;

    private void Awake()
    {
        curBulletPool = bulletPool[0];
    }

    private void Update()
    {
        Move();

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
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwapBullet(2);
        }
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector3.forward * z * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, x * rotateSpeed * Time.deltaTime);
    }

    private void Fire()
    {
        curBulletPool.GetPool(muzzlePoint.position, muzzlePoint.rotation);
    }

    private void SwapBullet(int index)
    {
        curBulletPool = bulletPool[index];
    }
}
