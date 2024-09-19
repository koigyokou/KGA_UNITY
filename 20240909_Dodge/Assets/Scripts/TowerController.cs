using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] Transform target;

    
    [SerializeField] GameObject bulletPrefab;   // 생성할 총알 프리팹
    [SerializeField] float bulletTimeCycle;  // 총알 생성 주기
    [SerializeField] float nextBulletTime;  // 다음 총알 생성 할때까지 기다린시간
    [SerializeField] bool isAttacking;  // 공격 여부

    private void Start()
    {

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player"); //태그 Player 오브젝트 검색

        target = playerObj.GetComponent<Transform>();//게임오브젝트에 있는 컴포넌트 가져오기

        target = playerObj.transform; // 타겟은 플레이어오브젝트의 트랜스폼 정보
    }

    private void Update()
    {

        if (isAttacking == false) // 공격중이 아니면 함수 중단
            return;

        nextBulletTime -= Time.deltaTime; // 1초씩 차감

        if (nextBulletTime <= 0) // 다음 불릿 생성 시기가 되면(시간이 0이하이면
        {

            GameObject bulletGameObj = Instantiate(bulletPrefab, transform.position, transform.rotation); // 불릿게임오브젝트 생성(프리팹, 포지션, 회전값)
            Bullet bullet = bulletGameObj.GetComponent<Bullet>(); // 생성한 불릿게임오브젝트 컴포넌트 가져오기
            bullet.SetTarget(target);// 불릿의 타겟을 target으로 설정

            nextBulletTime = bulletTimeCycle;// 다음 불릿을 생성할때까지 남은 시간을 다시 설정
        }
    }

    public void StartAttack()
    {
        isAttacking = true; // 공격 여부 참
    }

    public void StopAttack()
    {
        isAttacking = false; // 공격 여부 거짓
    }
}
