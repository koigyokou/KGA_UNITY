using UnityEngine;

public class BODY : MonoBehaviour
{
    [SerializeField] PROPEL propel;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float minLimitOfFly;

    private void Move()
    {
        if (transform.position.y <= 0) // ���麸�� ������ ���� �״�� �Լ� ����
            return;

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector3.forward * z * moveSpeed * Time.deltaTime); // �յ� �̵��� ����3�� �չ��⿡ �ӵ��� ��ŸŸ�� ���Ѱ�����
        transform.Rotate(Vector3.up, x * rotationSpeed * Time.deltaTime);// ȸ���� ������
    }
    private void Fly()
    {
        if (Input.GetButton("Jump"))
        {
            propel.SpeedUp(); // ������ ��ũ��Ʈ�� ���ǵ�� �Լ�
        }
        else
        {
            propel.SpeedDown();// ������ ��ũ��Ʈ�� ���ǵ�ٿ� �Լ�
        }

        transform.Translate(Vector3.up * (propel.RotationSpeed - minLimitOfFly) / 100 * Time.deltaTime);// translate�� ��ġ �̵� ����

        float posY = Mathf.Clamp(transform.position.y, 0, 50);// ��ġ �̵� ���� (�����Ҵ��,�ּ�ġ,�ִ�ġ)
        transform.position = new Vector3(transform.position.x, posY, transform.position.z);// ��ġ Ư��? -> x y z ��ǥ��.
    }

    private void Update()
    {
        Move();
        Fly();
    }
}
