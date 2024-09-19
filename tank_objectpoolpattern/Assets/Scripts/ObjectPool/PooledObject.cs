using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    private ObjectPool pool;
    public ObjectPool Pool { get { return pool; } set { pool = value; } }

    public void ReturnToPool()//Ǯ�� ��������
    {
        if (pool != null)//Ǯ�� �ƹ��͵� ���°� �ƴ϶��
        {
            pool.ReturnPool(this);//����Ǯ �ڱ��ڽ�
        }
        else
        {
            Destroy(gameObject);//Ǯ�� �ƹ��͵� ���ٸ� ���ֱ�
        }
    }
}
