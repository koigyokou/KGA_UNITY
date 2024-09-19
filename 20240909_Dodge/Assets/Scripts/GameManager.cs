using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState { Ready, Running, GameOver }

    [SerializeField] GameState curState;
    [SerializeField] PlayerController player;
    [SerializeField] TowerController[] towers;

    [Header("UI")]
    [SerializeField] GameObject readyText;
    [SerializeField] GameObject gameOverText;

    private void Start()//게임 시작시
    {
        curState = GameState.Ready; // 커런트스테이트를 레디로 변경

        towers = FindObjectsOfType<TowerController>(); // towers는 TowerController 오브젝트들

        player = FindObjectOfType<PlayerController>();// Player는 PlayerController 오브젝트
        player.OnDied += GameOver; // 플레이어에 온다이드 이벤트에 게임오버 추가

        readyText.SetActive(true); // 레디 텍스트 활성화
        gameOverText.SetActive(false);//게임오버 텍스트 비활성화
    }

    private void Update()
    {
        if (curState == GameState.Ready && Input.anyKeyDown) // 현재 게임 상태가 레디 이고, 아무키나 입력하면
        {
            GameStart(); // 게임시작
        }
        else if (curState == GameState.GameOver && Input.GetKeyDown(KeyCode.R)) // 현재 게임 상태가 게임오버 이고, R이 눌리면
        {
            SceneManager.LoadScene("DodgeScene"); // 닷지신 로드
        }
    }

    public void GameStart()
    {
        curState = GameState.Running; // 현재 상태를 러닝으로 바꿈

        foreach (TowerController tower in towers) // towers 순회반복
        {
            tower.StartAttack(); // 공격 시작
        }

        readyText.SetActive(false); // 레디, 게임오버 텍스트 비활성화
        gameOverText.SetActive(false);
    }

    public void GameOver()
    {
        curState = GameState.GameOver; // 현재 상태를 게임 오버로 바꿈

        foreach (TowerController tower in towers) // towers 순회반복
        {
            tower.StopAttack(); // 공격 중지
        }

        readyText.SetActive(false); // 레디 텍스트 비활성화
        gameOverText.SetActive(true); // 게임오버 텍스트 활성화
    }
}
