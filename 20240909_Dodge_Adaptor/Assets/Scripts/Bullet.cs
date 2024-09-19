using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody rigidBullet;
    [SerializeField] float speed;
    [SerializeField] Transform target;

    private void Start()
    {

        transform.LookAt(target.position);// Ÿ���� ������ �������� �ٶ󺸱�

        rigidBullet.velocity = transform.forward * speed;// �չ��⿡ ���ǵ� ���� ������ �ӵ� ����
    }

    public void SetTarget(Transform target)
    {
        this.target = target;// �ڱ��ڽ�(�μ��� ���� ��)�� Ÿ������ ����
    }

    private void OnCollisionEnter(Collision collision)// �浹 ���۽�
    {

        if (collision.gameObject.tag == "Player")// �÷��̾� �±׸� ���� ������Ʈ�� �浹�ߴٸ�
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();// �÷��̾� ��Ʈ�ѷ� ��������
            playerController.TakeHit(); // ����
        }
        Destroy(gameObject);//���ӿ�����Ʈ ����
    }
}
