using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] Monster[] monsters;
    [SerializeField] float respawnTime;
    [SerializeField] float randomRange;

    public void Respawn(Monster monster) // ���͸� �μ��� �޴� ������ �Լ� 
    {
        StartCoroutine(RespawnRoutine(monster)); // �ڷ�ƾ ����
    }

    IEnumerator RespawnRoutine(Monster monster) // �ڷ�ƾ ����
    {
        monster.gameObject.SetActive(false); // ������Ʈ ��Ȱ��ȭ

        yield return new WaitForSeconds(respawnTime); // ������ Ÿ�� ��ŭ ��ٷȴٰ�

        monster.transform.position = new Vector3(Random.Range(-randomRange, randomRange), 0.5f, Random.Range(-randomRange, randomRange)); // (��������,0.5,��������)�� ����
        monster.gameObject.SetActive(true);// ������Ʈ Ȱ��ȭ
        monster.ResetHP(); // ���� HP
    }
}
