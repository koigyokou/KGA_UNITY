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
        if (bestScore < score) // 베스트 스코어가 스코어보다 작다면
        {
            bestScore = score; // 베스트스코어에 스코어 대입
        }
    }

    private void Awake()
    {
        if (Instance == null)// 인스턴스가 null이라면
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);// 인스턴스를 자기자신을 대입하고 게임오브젝트 유지
        }
        else// 반대라면
        {
            Destroy(gameObject); // 게임오브젝트 삭제
        }
    }
}
