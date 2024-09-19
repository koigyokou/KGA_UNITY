using UnityEngine;
using UnityEngine.Events;

// ������Ʈ : ���ӿ�����Ʈ�� ����� ����ϴ� ��ǰ
public class PlayerController : MonoBehaviour
{
    // �ν����� â���� �����ϰų� ���� �������־ ���� ���
    // �ɹ����� : ����
    [SerializeField] Rigidbody rigidPlayer;
    [SerializeField] float moveSpeed;

    public UnityEvent OnDied;
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(x, 0, z);
        if (moveDir.sqrMagnitude > 1)  // magnitude : ������ ũ�� / sqrMagnitude : ������ ũ���� ����, ��Ʈ ����� �������� ����(����ȭ�� �� ����)
        {
            moveDir.Normalize();// ������ 1�� ������ : ���������� �Ÿ��� 1�̻��̸� // ����ȭ ����
        }

        rigidPlayer.velocity = moveDir * moveSpeed;
    }

    public void TakeHit()
    {
        OnDied?.Invoke();// �´��̵� �̺�Ʈ? ȣ��
        Destroy(gameObject); // ������Ʈ ����
    }

    // 
    //
    //�� �κ� �� �𸣰ڽ��ϴ� ��
    //
    //
    //
    //
    //
    private void OnCollisionEnter(Collision collision)
    {
        IContactable contactable = collision.gameObject.GetComponent<IContactable>();
        contactable?.Contact(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        IContactable contactable = other.gameObject.GetComponent<IContactable>();
        contactable?.Contact(this);
    }
}
