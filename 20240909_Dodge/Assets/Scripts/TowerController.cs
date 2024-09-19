using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] Transform target;

    
    [SerializeField] GameObject bulletPrefab;   // ������ �Ѿ� ������
    [SerializeField] float bulletTimeCycle;  // �Ѿ� ���� �ֱ�
    [SerializeField] float nextBulletTime;  // ���� �Ѿ� ���� �Ҷ����� ��ٸ��ð�
    [SerializeField] bool isAttacking;  // ���� ����

    private void Start()
    {

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player"); //�±� Player ������Ʈ �˻�

        target = playerObj.GetComponent<Transform>();//���ӿ�����Ʈ�� �ִ� ������Ʈ ��������

        target = playerObj.transform; // Ÿ���� �÷��̾������Ʈ�� Ʈ������ ����
    }

    private void Update()
    {

        if (isAttacking == false) // �������� �ƴϸ� �Լ� �ߴ�
            return;

        nextBulletTime -= Time.deltaTime; // 1�ʾ� ����

        if (nextBulletTime <= 0) // ���� �Ҹ� ���� �ñⰡ �Ǹ�(�ð��� 0�����̸�
        {

            GameObject bulletGameObj = Instantiate(bulletPrefab, transform.position, transform.rotation); // �Ҹ����ӿ�����Ʈ ����(������, ������, ȸ����)
            Bullet bullet = bulletGameObj.GetComponent<Bullet>(); // ������ �Ҹ����ӿ�����Ʈ ������Ʈ ��������
            bullet.SetTarget(target);// �Ҹ��� Ÿ���� target���� ����

            nextBulletTime = bulletTimeCycle;// ���� �Ҹ��� �����Ҷ����� ���� �ð��� �ٽ� ����
        }
    }

    public void StartAttack()
    {
        isAttacking = true; // ���� ���� ��
    }

    public void StopAttack()
    {
        isAttacking = false; // ���� ���� ����
    }
}
