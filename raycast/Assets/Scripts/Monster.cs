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

    public void TakeHit(int damage) //�ǰ� �Լ� : bullet ��ũ��Ʈ���� ����
    {
        curHP -= damage; // ��������ŭ ü���� ����
        if (curHP <= 0) // ü���� 0�����̸�
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        curHP = maxHP;
        transform.position = new Vector3(Random.Range(-randomRange, randomRange), 0.5f, Random.Range(-randomRange, randomRange)); // x,z�� ���� y �� 0.5 ��ġ�� ����
    }
}
