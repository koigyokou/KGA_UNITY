using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class Monster : MonoBehaviour
{
    [SerializeField] int curHP;
    [SerializeField] int maxHP;

    public UnityEvent<Monster> OnDied; //유니티 이벤트 생성

    private void Start() // 시작하면 리셋
    {
        ResetHP();
    }

    public void TakeHit(int damage) // damage 입력 받아서...
    {
        curHP -= damage;
        if (curHP <= 0)// 체력이 0보다 적어지면
        {
            OnDied?.Invoke(this); // 유니티이벤트 발생
            Die();
        }
    }

    private void Die()//오브젝트 비활성화
    {
        gameObject.SetActive(false);
    }

    public void ResetHP()// 체력 리셋
    {
        curHP = maxHP;
    }
}
