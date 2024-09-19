using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;
    [SerializeField] float speed;
    [SerializeField] int damage;

    private void Start()
    {
        rigid.velocity = transform.forward * speed; // 총알의 속도는 z방향에 속력을 곱한 값
    }

    private void OnCollisionEnter(Collision collision)// 충돌시 :
    {
        Monster monster = collision.gameObject.GetComponent<Monster>(); // 몬스터 참조
        if (monster != null)// 몬스터가 null이 아니라면
        {
            monster.TakeHit(damage);//Monster 스크립트에 있던 메소드
        }

        Destroy(gameObject); // 이외에는 몬스터 파괴
    }
}
