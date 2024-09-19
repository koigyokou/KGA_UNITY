using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody rigidBullet;
    [SerializeField] float speed;
    [SerializeField] Transform target;

    private void Start()
    {

        transform.LookAt(target.position);// 타겟의 포지션 방향으로 바라보기

        rigidBullet.velocity = transform.forward * speed;// 앞방향에 스피드 곱한 값으로 속도 지정
    }

    public void SetTarget(Transform target)
    {
        this.target = target;// 자기자신(인수로 받은 것)을 타겟으로 지정
    }

    private void OnCollisionEnter(Collision collision)// 충돌 시작시
    {

        if (collision.gameObject.tag == "Player")// 플레이어 태그를 가진 오브젝트와 충돌했다면
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();// 플레이어 컨트롤러 가져오기
            playerController.TakeHit(); // 맞음
        }
        Destroy(gameObject);//게임오브젝트 삭제
    }
}
