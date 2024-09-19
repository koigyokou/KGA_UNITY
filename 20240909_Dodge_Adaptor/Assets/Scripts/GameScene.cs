using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScene : MonoBehaviour
{
    public enum GameState { Ready, Running, GameOver, Clear } // 열거형 : 레디 러닝 게임오버 클리어 

    [SerializeField] GameState curState;
    [SerializeField] TowerController[] towers;
    [SerializeField] GameObject clearZone;

    [SerializeField] int curScore;

    [Header("UI")]
    [SerializeField] GameObject readyText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject clearText;
    [SerializeField] Text bestScoreText;
    [SerializeField] Text curScoreText;

    private void Start()
    {
        curState = GameState.Ready; // 시작하면 현재상태를 레디로 바꿈

        // 게임씬에 있는 모든 컴포넌트 찾기
        // 단, 시간이 오래걸리는 함수이기 때문에 로딩 과정에서 사용 권장
        towers = FindObjectsOfType<TowerController>(); // towers 는 TowerController 타입 오브젝트

        readyText.SetActive(true); // 레디 문구 출력
        gameOverText.SetActive(false); // 게임오버 문구 비출력
        clearText.SetActive(false); // 클리어 문구 비출력
        curScoreText.text = $"현재 점수 : {curScore}"; // 현재점수 : curScore값
        bestScoreText.text = $"최고 점수 : {GameManager.Instance.BestScore}"; // 베스트점수 : Instance.BestScore값
    }

    private void Update()
    {
        if (curState == GameState.Ready && Input.anyKeyDown) // 레디 상태이고 아무키나 눌리면(둘다)
        {
            GameStart(); // 게임 시작
        }
        else if (curState == GameState.GameOver && Input.GetKeyDown(KeyCode.R)) // 게임오버상태이고 R 눌리면(둘다)
        {
            SceneManager.LoadScene("DodgeScene");//닷지신 로드
        }
        else if (curState == GameState.Clear && Input.GetKeyDown(KeyCode.R)) // 클리어상태이고 R 눌리면 (둘다)
        {
            SceneManager.LoadScene("DodgeScene");//닷지신 로드
        }
    }

    Coroutine scoreRoutine; // 코루틴 선언
    IEnumerator ScoreRoutine() // 코루틴 선언
    {
        WaitForSeconds delay = new WaitForSeconds(1f); // 1초 기다림값 설정 (delay)
        while (true)
        {
            yield return delay;// 1초 기다림
            curScore++;// 스코어 +1
            curScoreText.text = $"현재 점수 : {curScore}"; // 현재 점수 갱신

            if (curScore >= 20) // 현재 점수가 20이상이면
            {
                clearZone.SetActive(true); // 클리어존 활성화
            }

            GameManager.Instance.SetBestScore(curScore); // 최고 점수 갱신
            bestScoreText.text = $"최고 점수 : {GameManager.Instance.BestScore}"; // 최고 점수 갱신
        }
    }

    public void GameStart() // 게임 시작 함수 
    {
        curState = GameState.Running; // 게임스테이트 러닝으로 바꿈
        // 타워들 공격개시
        foreach (TowerController tower in towers) // 순회 반복
        {
            tower.StartAttack(); // 공격 시작
        }

        readyText.SetActive(false); // 레디 게임오버 클리어 문구 비활성화
        gameOverText.SetActive(false);
        clearText.SetActive(false);

        scoreRoutine = StartCoroutine(ScoreRoutine()); // 스코어루틴 코루틴 시작
    }

    public void GameOver() // 게임 오버 함수
    {
        curState = GameState.GameOver; // 스테이트를 게임오버로 바꿈
        // 타워들 공격중지
        foreach (TowerController tower in towers) // 순회 반복 
        {
            tower.StopAttack();// 공격 중지
        }

        readyText.SetActive(false); // 레디 문구 비활성화
        gameOverText.SetActive(true);// 게임오버 문구 활성화
        clearText.SetActive(false);// 클리어 문구 비활성화

        StopCoroutine(scoreRoutine); // 스코어루틴 코루틴 중지
    }

    public void GameClear() // 게임 클리어 함수
    {
        curState = GameState.GameOver; // 게임오버로 스테이트 변경
        // 타워들 공격중지
        foreach (TowerController tower in towers) // 순회 반복
        {
            tower.StopAttack();// 공격 중지
        }

        readyText.SetActive(false); // 레디 게임오버 문구 비활성화
        gameOverText.SetActive(false);
        clearText.SetActive(true);// 클리어 문구 활성화

        StopCoroutine(scoreRoutine); // 스코어루틴 코루틴 중지
    }
}
