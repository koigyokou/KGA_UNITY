using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    private ObjectPool pool;
    public ObjectPool Pool { get { return pool; } set { pool = value; } }

    public void ReturnToPool()//풀에 돌려놓기
    {
        if (pool != null)//풀에 아무것도 없는게 아니라면
        {
            pool.ReturnPool(this);//리턴풀 자기자신
        }
        else
        {
            Destroy(gameObject);//풀에 아무것도 없다면 없애기
        }
    }
}
