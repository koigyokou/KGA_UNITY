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
        Cursor.lockState = CursorLockMode.Locked; // (마우스)커서 중앙에 고정 
    }

    private void Update()
    {
        Move();
        Look();

        if (Input.GetButtonDown("Fire1"))
        {
            fireRepeatRoutine = StartCoroutine(FireRepeatRoutine());//좌클릭시 코루틴 시작 ----- 코루틴 변수?에 넣어줘야함
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fireRepeatRoutine); // 코루틴 멈춤 ----- 스탑코루틴만 하는게 아니라 코루틴 변수?를 멈춰줘야함
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();// r키로 재장전
        }
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(x, 0, z); // 전후좌우 움직임으로 만듦
        if (moveDir.sqrMagnitude > 1)
        {
            moveDir.Normalize();// 벡터 노멀라이즈
        }

        transform.Translate(moveDir * moveSpeed * Time.deltaTime); // 위치이동을 translate로 구현
    }

    private void Look()
    {
        float x = Input.GetAxisRaw("Mouse X");
        float y = Input.GetAxisRaw("Mouse Y");

        transform.Rotate(Vector3.up, x * camRotateSpeed * Time.deltaTime); // 벡터 업 방향으로 마우스 움직임대로
        camTransform.Rotate(Vector3.right, -y * camRotateSpeed * Time.deltaTime);// 벡터 라이트 방향으로 마우스 움직임대로
    }

    Coroutine fireRepeatRoutine;// 코루틴 선언
    IEnumerator FireRepeatRoutine()// 코루틴 선언
    {
        WaitForSeconds delay = new WaitForSeconds(repeatTime); // 리피트타임만큼 기다림_1

        while (true)
        {
            Fire();
            yield return delay;// 리피트타임만큼 기다림_2
        }
    }

    private void Reload()
    {
        if (isReloading) // 재장전 중이라면 함수 종료
            return;

        StartCoroutine(ReloadRoutine()); // 호출시 재장전 코루틴 시작
    }

    IEnumerator ReloadRoutine()// 재장전 코루틴 선언
    {
        Debug.Log("재장전 시작!");
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        curBullet = maxBullet;
        isReloading = false;
        Debug.Log("재장전 완료!");
    }

    private void Fire()
    {
        if (curBullet <= 0)// 현재 총알이 0이하이면 탄알부족 출력 / 함수 종료
        {
            Debug.Log("탄알 부족!");
            return;
        }

        if (isReloading == true)// 재장전 중이라면 재장전 중... 출력 / 함수 종료
        {
            Debug.Log("재장전 중...");
            return;
        }

        curBullet--; // 함수 호출당 하나씩 총알 줄이기
        Debug.Log($"Fire {curBullet} / {maxBullet}");//남은 총알 출력
        if (Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit hit)) // 레이캐스트 (카메라위치에서, 앞방향으로, )맞았다면
        {
            Monster monster = hit.collider.GetComponent<Monster>();
            if (monster != null)
            {
                monster.TakeHit(damage); // 몬스터 피격(데미지만큼)
            }
        }
    }
}
