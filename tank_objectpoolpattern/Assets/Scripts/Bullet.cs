using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] PooledObject pooledObject;
    [SerializeField] float moveSpeed;
    [SerializeField] float returnTime;

    private float remainTime;//이렇게 해줘야 총알별로 남은시간이 따로 돌아감

    private void OnEnable()//이렇게 해줘야 총알별로 남은시간이 따로 돌아감
    {
        remainTime = returnTime;//이렇게 해줘야 총알별로 남은시간이 따로 돌아감
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);//발사

        remainTime -= Time.deltaTime;//총알 남은 시간 줄이고
        if (remainTime < 0)//0보다 작아지면
        {
            pooledObject.ReturnToPool();//풀로 돌려보내기
        }
    }
}
