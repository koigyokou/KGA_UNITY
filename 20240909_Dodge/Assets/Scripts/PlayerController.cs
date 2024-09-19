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
        Move(); // 무브 함수 업데이트에서 계속 돌림
    }

    private void Move()
    {
        // 입력시스템에서 선언되어 있음
        float x = Input.GetAxisRaw("Horizontal"); // 좌우
        float z = Input.GetAxisRaw("Vertical"); // 전후

        Vector3 moveDir = new Vector3(x, 0, z); // 무브디렉션 벡터중 x z 값 가져오기
        if (moveDir.sqrMagnitude > 1)  // magnitude : 백터의 크기 / sqrMagnitude : 벡터의 크기의 제곱, 루트 계산을 진행하지 않음(최적화에 더 좋음)
        {
            moveDir.Normalize(); // 제곱이 1을 넘으면 : 원점에서의 거리가 1이상이면 // 정규화 진행
        }

        rigidPlayer.velocity = moveDir * moveSpeed; // 속도는 무브디렉션 곱하기 무브스피드
    }

    public void TakeHit()
    {
        OnDied?.Invoke(); // 온다이드 이벤트? 호출
        Destroy(gameObject); // 오브젝트 삭제
    }
}
