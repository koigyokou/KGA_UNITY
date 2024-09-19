using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] int maxHP;
    [SerializeField] float randomRange;

    private int curHP;

    private void Start()
    {
        Spawn();
    }

    public void TakeHit(int damage) //피격 함수 : bullet 스크립트에서 쓰임
    {
        curHP -= damage; // 데미지만큼 체력을 줄임
        if (curHP <= 0) // 체력이 0이하이면
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        curHP = maxHP;
        transform.position = new Vector3(Random.Range(-randomRange, randomRange), 0.5f, Random.Range(-randomRange, randomRange)); // x,z는 랜덤 y 는 0.5 위치에 생성
    }
}
