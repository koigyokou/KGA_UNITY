using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] PooledObject pooledObject;
    [SerializeField] float moveSpeed;
    [SerializeField] float returnTime;

    private float remainTime;//�̷��� ����� �Ѿ˺��� �����ð��� ���� ���ư�

    private void OnEnable()//�̷��� ����� �Ѿ˺��� �����ð��� ���� ���ư�
    {
        remainTime = returnTime;//�̷��� ����� �Ѿ˺��� �����ð��� ���� ���ư�
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);//�߻�

        remainTime -= Time.deltaTime;//�Ѿ� ���� �ð� ���̰�
        if (remainTime < 0)//0���� �۾�����
        {
            pooledObject.ReturnToPool();//Ǯ�� ����������
        }
    }
}
