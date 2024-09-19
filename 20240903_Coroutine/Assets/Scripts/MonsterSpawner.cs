using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] Monster[] monsters;
    [SerializeField] float respawnTime;
    [SerializeField] float randomRange;

    public void Respawn(Monster monster) // 몬스터를 인수로 받는 리스폰 함수 
    {
        StartCoroutine(RespawnRoutine(monster)); // 코루틴 시작
    }

    IEnumerator RespawnRoutine(Monster monster) // 코루틴 선언
    {
        monster.gameObject.SetActive(false); // 오브젝트 비활성화

        yield return new WaitForSeconds(respawnTime); // 리스폰 타임 만큼 기다렸다가

        monster.transform.position = new Vector3(Random.Range(-randomRange, randomRange), 0.5f, Random.Range(-randomRange, randomRange)); // (랜덤범위,0.5,랜덤범위)에 지정
        monster.gameObject.SetActive(true);// 오브젝트 활성화
        monster.ResetHP(); // 리셋 HP
    }
}
