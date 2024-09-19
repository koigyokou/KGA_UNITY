using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] PooledObject prefab; //프리팹 지정
    [SerializeField] bool createOnEmpty = true; // 다 쓰고 있을 때 생성 여부
    [SerializeField] int size; // 사이즈
    [SerializeField] int capacity; // 용량

    private Stack<PooledObject> pool;

    private void Awake()
    {
        pool = new Stack<PooledObject>(capacity);//스택 선언
        for (int i = 0; i < size; i++)// 스택에 사이즈만큼 총알 밀어넣기
        {
            PooledObject instance = Instantiate(prefab);
            instance.gameObject.SetActive(false);//프리팹은 아직 생성 x
            instance.Pool = this;
            pool.Push(instance);//스택 밀어넣기
        }
    }

    public PooledObject GetPool(Vector3 position, Quaternion rotation)//풀에서 꺼내오기
    {
        if (pool.Count > 0)
        {
            PooledObject instance = pool.Pop();//스택에서 꺼내기
            instance.transform.position = position;//위치는 그대로
            instance.transform.rotation = rotation;//회전도 그대로
            instance.gameObject.SetActive(true);//프리팹 씬에 생성
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

    public void ReturnPool(PooledObject instance)//풀에 돌려놓기
    {
        if (pool.Count < capacity)//용량보다 적다면
        {
            instance.gameObject.SetActive(false);//멈추고
            pool.Push(instance);//스택에 다시 밀어넣기
        }
        else
        {
            Destroy(instance.gameObject);//용량보다 크다면 없애버리기
        }
    }
}
