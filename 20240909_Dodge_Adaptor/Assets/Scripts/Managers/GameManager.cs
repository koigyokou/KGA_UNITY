using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] int bestScore;
    public int BestScore { get { return bestScore; } }

    public void SetBestScore(int score)
    {
        if (bestScore < score) // ����Ʈ ���ھ ���ھ�� �۴ٸ�
        {
            bestScore = score; // ����Ʈ���ھ ���ھ� ����
        }
    }

    private void Awake()
    {
        if (Instance == null)// �ν��Ͻ��� null�̶��
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);// �ν��Ͻ��� �ڱ��ڽ��� �����ϰ� ���ӿ�����Ʈ ����
        }
        else// �ݴ���
        {
            Destroy(gameObject); // ���ӿ�����Ʈ ����
        }
    }
}
