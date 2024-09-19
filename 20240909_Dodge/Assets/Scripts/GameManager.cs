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

    private void Start()//���� ���۽�
    {
        curState = GameState.Ready; // Ŀ��Ʈ������Ʈ�� ����� ����

        towers = FindObjectsOfType<TowerController>(); // towers�� TowerController ������Ʈ��

        player = FindObjectOfType<PlayerController>();// Player�� PlayerController ������Ʈ
        player.OnDied += GameOver; // �÷��̾ �´��̵� �̺�Ʈ�� ���ӿ��� �߰�

        readyText.SetActive(true); // ���� �ؽ�Ʈ Ȱ��ȭ
        gameOverText.SetActive(false);//���ӿ��� �ؽ�Ʈ ��Ȱ��ȭ
    }

    private void Update()
    {
        if (curState == GameState.Ready && Input.anyKeyDown) // ���� ���� ���°� ���� �̰�, �ƹ�Ű�� �Է��ϸ�
        {
            GameStart(); // ���ӽ���
        }
        else if (curState == GameState.GameOver && Input.GetKeyDown(KeyCode.R)) // ���� ���� ���°� ���ӿ��� �̰�, R�� ������
        {
            SceneManager.LoadScene("DodgeScene"); // ������ �ε�
        }
    }

    public void GameStart()
    {
        curState = GameState.Running; // ���� ���¸� �������� �ٲ�

        foreach (TowerController tower in towers) // towers ��ȸ�ݺ�
        {
            tower.StartAttack(); // ���� ����
        }

        readyText.SetActive(false); // ����, ���ӿ��� �ؽ�Ʈ ��Ȱ��ȭ
        gameOverText.SetActive(false);
    }

    public void GameOver()
    {
        curState = GameState.GameOver; // ���� ���¸� ���� ������ �ٲ�

        foreach (TowerController tower in towers) // towers ��ȸ�ݺ�
        {
            tower.StopAttack(); // ���� ����
        }

        readyText.SetActive(false); // ���� �ؽ�Ʈ ��Ȱ��ȭ
        gameOverText.SetActive(true); // ���ӿ��� �ؽ�Ʈ Ȱ��ȭ
    }
}
