using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScene : MonoBehaviour
{
    public enum GameState { Ready, Running, GameOver, Clear } // ������ : ���� ���� ���ӿ��� Ŭ���� 

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
        curState = GameState.Ready; // �����ϸ� ������¸� ����� �ٲ�

        // ���Ӿ��� �ִ� ��� ������Ʈ ã��
        // ��, �ð��� �����ɸ��� �Լ��̱� ������ �ε� �������� ��� ����
        towers = FindObjectsOfType<TowerController>(); // towers �� TowerController Ÿ�� ������Ʈ

        readyText.SetActive(true); // ���� ���� ���
        gameOverText.SetActive(false); // ���ӿ��� ���� �����
        clearText.SetActive(false); // Ŭ���� ���� �����
        curScoreText.text = $"���� ���� : {curScore}"; // �������� : curScore��
        bestScoreText.text = $"�ְ� ���� : {GameManager.Instance.BestScore}"; // ����Ʈ���� : Instance.BestScore��
    }

    private void Update()
    {
        if (curState == GameState.Ready && Input.anyKeyDown) // ���� �����̰� �ƹ�Ű�� ������(�Ѵ�)
        {
            GameStart(); // ���� ����
        }
        else if (curState == GameState.GameOver && Input.GetKeyDown(KeyCode.R)) // ���ӿ��������̰� R ������(�Ѵ�)
        {
            SceneManager.LoadScene("DodgeScene");//������ �ε�
        }
        else if (curState == GameState.Clear && Input.GetKeyDown(KeyCode.R)) // Ŭ��������̰� R ������ (�Ѵ�)
        {
            SceneManager.LoadScene("DodgeScene");//������ �ε�
        }
    }

    Coroutine scoreRoutine; // �ڷ�ƾ ����
    IEnumerator ScoreRoutine() // �ڷ�ƾ ����
    {
        WaitForSeconds delay = new WaitForSeconds(1f); // 1�� ��ٸ��� ���� (delay)
        while (true)
        {
            yield return delay;// 1�� ��ٸ�
            curScore++;// ���ھ� +1
            curScoreText.text = $"���� ���� : {curScore}"; // ���� ���� ����

            if (curScore >= 20) // ���� ������ 20�̻��̸�
            {
                clearZone.SetActive(true); // Ŭ������ Ȱ��ȭ
            }

            GameManager.Instance.SetBestScore(curScore); // �ְ� ���� ����
            bestScoreText.text = $"�ְ� ���� : {GameManager.Instance.BestScore}"; // �ְ� ���� ����
        }
    }

    public void GameStart() // ���� ���� �Լ� 
    {
        curState = GameState.Running; // ���ӽ�����Ʈ �������� �ٲ�
        // Ÿ���� ���ݰ���
        foreach (TowerController tower in towers) // ��ȸ �ݺ�
        {
            tower.StartAttack(); // ���� ����
        }

        readyText.SetActive(false); // ���� ���ӿ��� Ŭ���� ���� ��Ȱ��ȭ
        gameOverText.SetActive(false);
        clearText.SetActive(false);

        scoreRoutine = StartCoroutine(ScoreRoutine()); // ���ھ��ƾ �ڷ�ƾ ����
    }

    public void GameOver() // ���� ���� �Լ�
    {
        curState = GameState.GameOver; // ������Ʈ�� ���ӿ����� �ٲ�
        // Ÿ���� ��������
        foreach (TowerController tower in towers) // ��ȸ �ݺ� 
        {
            tower.StopAttack();// ���� ����
        }

        readyText.SetActive(false); // ���� ���� ��Ȱ��ȭ
        gameOverText.SetActive(true);// ���ӿ��� ���� Ȱ��ȭ
        clearText.SetActive(false);// Ŭ���� ���� ��Ȱ��ȭ

        StopCoroutine(scoreRoutine); // ���ھ��ƾ �ڷ�ƾ ����
    }

    public void GameClear() // ���� Ŭ���� �Լ�
    {
        curState = GameState.GameOver; // ���ӿ����� ������Ʈ ����
        // Ÿ���� ��������
        foreach (TowerController tower in towers) // ��ȸ �ݺ�
        {
            tower.StopAttack();// ���� ����
        }

        readyText.SetActive(false); // ���� ���ӿ��� ���� ��Ȱ��ȭ
        gameOverText.SetActive(false);
        clearText.SetActive(true);// Ŭ���� ���� Ȱ��ȭ

        StopCoroutine(scoreRoutine); // ���ھ��ƾ �ڷ�ƾ ����
    }
}
