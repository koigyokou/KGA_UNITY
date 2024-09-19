using UnityEngine;

public class PROPEL : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] float rotationAcceleration;
    [SerializeField] float rotationDeceleration;
    [SerializeField] float maxRotationSpeed;
    public float RotationSpeed { get { return rotationSpeed; } set { rotationSpeed = value; } }

    public void SpeedUp()//�����緯 ȸ�� �ӵ� ��
    {
        RotationSpeed += rotationAcceleration * Time.deltaTime;// �׼������̼� ��ġ��ŭ(��ŸŸ���� ���ؼ�) ��� ������.

        if (RotationSpeed > maxRotationSpeed)// �ִ�ġ���������� ����
        {
            RotationSpeed = maxRotationSpeed;
        }
    }

    public void SpeedDown()
    {
        rotationSpeed -= rotationDeceleration * Time.deltaTime;// �׼������̼� ��ġ��ŭ(��ŸŸ���� ���ؼ�) ��� ����.

        if (rotationSpeed < 0)// 0���� ������ �׳� 0���� ����
        {
            rotationSpeed = 0;
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }





}
