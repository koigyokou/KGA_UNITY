using UnityEngine;

public class PROPEL : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] float rotationAcceleration;
    [SerializeField] float rotationDeceleration;
    [SerializeField] float maxRotationSpeed;
    public float RotationSpeed { get { return rotationSpeed; } set { rotationSpeed = value; } }

    public void SpeedUp()//프로펠러 회전 속도 업
    {
        RotationSpeed += rotationAcceleration * Time.deltaTime;// 액셀러레이션 수치만큼(델타타임을 곱해서) 계속 더해줌.

        if (RotationSpeed > maxRotationSpeed)// 최대치까지만으로 제한
        {
            RotationSpeed = maxRotationSpeed;
        }
    }

    public void SpeedDown()
    {
        rotationSpeed -= rotationDeceleration * Time.deltaTime;// 액셀러레이션 수치만큼(델타타임을 곱해서) 계속 빼줌.

        if (rotationSpeed < 0)// 0보다 작으면 그냥 0으로 고정
        {
            rotationSpeed = 0;
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }





}
