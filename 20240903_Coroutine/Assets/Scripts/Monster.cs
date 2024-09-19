using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class Monster : MonoBehaviour
{
    [SerializeField] int curHP;
    [SerializeField] int maxHP;

    public UnityEvent<Monster> OnDied; //����Ƽ �̺�Ʈ ����

    private void Start() // �����ϸ� ����
    {
        ResetHP();
    }

    public void TakeHit(int damage) // damage �Է� �޾Ƽ�...
    {
        curHP -= damage;
        if (curHP <= 0)// ü���� 0���� ��������
        {
            OnDied?.Invoke(this); // ����Ƽ�̺�Ʈ �߻�
            Die();
        }
    }

    private void Die()//������Ʈ ��Ȱ��ȭ
    {
        gameObject.SetActive(false);
    }

    public void ResetHP()// ü�� ����
    {
        curHP = maxHP;
    }
}
