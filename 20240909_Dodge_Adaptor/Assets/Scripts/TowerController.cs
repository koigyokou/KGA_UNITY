using System.Collections;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] GameObject bulletPrefab;   // ������ �Ѿ� ������
    [SerializeField] float bulletTimeCycle;  // �Ѿ� ���� �ֱ�
    [SerializeField] float nextBulletTime;  // ���� �Ѿ� ���� �Ҷ����� ��ٸ��ð�

    private void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player"); //�±� Player ������Ʈ �˻�

        target = playerObj.GetComponent<Transform>();//���ӿ�����Ʈ�� �ִ� ������Ʈ ��������

        target = playerObj.transform; // Ÿ���� �÷��̾������Ʈ�� Ʈ������ ����
    }

    public void StartAttack()
    {
        if (attackRoutine != null)//���÷�ƾ�� ���� �ƴϸ� �Լ�����
            return;

        attackRoutine = StartCoroutine(AttackRoutine());//���÷�ƾ �ڷ�ƾ ����
    }

    public void StopAttack()
    {
        if (attackRoutine == null)//���÷�ƾ�� ���̶�� �Լ�����
            return;

        StopCoroutine(attackRoutine);//���÷�ƾ �ڷ�ƾ ����
        attackRoutine = null; // ���� ��ƾ null��
    }

    Coroutine attackRoutine; // �ڷ�ƾ ����
    IEnumerator AttackRoutine() // �ڷ�ƾ ����
    {
        WaitForSeconds delay = new WaitForSeconds(bulletTimeCycle); // delay �Ҹ�Ÿ�Ӹ�ŭ ���

        while (true)
        {
            yield return delay; // �ڷ�ƾ �ֱ� ����

            GameObject bulletGameObj = Instantiate(bulletPrefab, transform.position, transform.rotation); // �Ҹ����ӿ�����Ʈ ����(������, ������, ȸ����)
            Bullet bullet = bulletGameObj.GetComponent<Bullet>(); // ������ �Ҹ����ӿ�����Ʈ ������Ʈ ��������
            bullet.SetTarget(target);// �Ҹ��� Ÿ���� target���� ����
        }
    }
}
