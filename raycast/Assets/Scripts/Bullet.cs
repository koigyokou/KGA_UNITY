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
        rigid.velocity = transform.forward * speed; // �Ѿ��� �ӵ��� z���⿡ �ӷ��� ���� ��
    }

    private void OnCollisionEnter(Collision collision)// �浹�� :
    {
        Monster monster = collision.gameObject.GetComponent<Monster>(); // ���� ����
        if (monster != null)// ���Ͱ� null�� �ƴ϶��
        {
            monster.TakeHit(damage);//Monster ��ũ��Ʈ�� �ִ� �޼ҵ�
        }

        Destroy(gameObject); // �̿ܿ��� ���� �ı�
    }
}
