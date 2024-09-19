using System.Collections;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] GameObject bulletPrefab;   // 생성할 총알 프리팹
    [SerializeField] float bulletTimeCycle;  // 총알 생성 주기
    [SerializeField] float nextBulletTime;  // 다음 총알 생성 할때까지 기다린시간

    private void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player"); //태그 Player 오브젝트 검색

        target = playerObj.GetComponent<Transform>();//게임오브젝트에 있는 컴포넌트 가져오기

        target = playerObj.transform; // 타겟은 플레이어오브젝트의 트랜스폼 정보
    }

    public void StartAttack()
    {
        if (attackRoutine != null)//어택루틴이 널이 아니면 함수종료
            return;

        attackRoutine = StartCoroutine(AttackRoutine());//어택루틴 코루틴 시작
    }

    public void StopAttack()
    {
        if (attackRoutine == null)//어택루틴이 널이라면 함수종료
            return;

        StopCoroutine(attackRoutine);//어택루틴 코루틴 중지
        attackRoutine = null; // 어택 루틴 null로
    }

    Coroutine attackRoutine; // 코루틴 선언
    IEnumerator AttackRoutine() // 코루틴 선언
    {
        WaitForSeconds delay = new WaitForSeconds(bulletTimeCycle); // delay 불릿타임만큼 대기

        while (true)
        {
            yield return delay; // 코루틴 주기 설정

            GameObject bulletGameObj = Instantiate(bulletPrefab, transform.position, transform.rotation); // 불릿게임오브젝트 생성(프리팹, 포지션, 회전값)
            Bullet bullet = bulletGameObj.GetComponent<Bullet>(); // 생성한 불릿게임오브젝트 컴포넌트 가져오기
            bullet.SetTarget(target);// 불릿의 타겟을 target으로 설정
        }
    }
}
