using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] PooledObject prefab; //������ ����
    [SerializeField] bool createOnEmpty = true; // �� ���� ���� �� ���� ����
    [SerializeField] int size; // ������
    [SerializeField] int capacity; // �뷮

    private Stack<PooledObject> pool;

    private void Awake()
    {
        pool = new Stack<PooledObject>(capacity);//���� ����
        for (int i = 0; i < size; i++)// ���ÿ� �����ŭ �Ѿ� �о�ֱ�
        {
            PooledObject instance = Instantiate(prefab);
            instance.gameObject.SetActive(false);//�������� ���� ���� x
            instance.Pool = this;
            pool.Push(instance);//���� �о�ֱ�
        }
    }

    public PooledObject GetPool(Vector3 position, Quaternion rotation)//Ǯ���� ��������
    {
        if (pool.Count > 0)
        {
            PooledObject instance = pool.Pop();//���ÿ��� ������
            instance.transform.position = position;//��ġ�� �״��
            instance.transform.rotation = rotation;//ȸ���� �״��
            instance.gameObject.SetActive(true);//������ ���� ����
            return instance;
        }
        else if (createOnEmpty)
        {
            PooledObject instance = Instantiate(prefab);
            instance.transform.position = position;
            instance.transform.rotation = rotation;
            instance.Pool = this;
            return instance;
        }
        else
        {
            return null;
        }
    }

    public void ReturnPool(PooledObject instance)//Ǯ�� ��������
    {
        if (pool.Count < capacity)//�뷮���� ���ٸ�
        {
            instance.gameObject.SetActive(false);//���߰�
            pool.Push(instance);//���ÿ� �ٽ� �о�ֱ�
        }
        else
        {
            Destroy(instance.gameObject);//�뷮���� ũ�ٸ� ���ֹ�����
        }
    }
}
