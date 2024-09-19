using UnityEngine;

public class BODY : MonoBehaviour
{
    [SerializeField] PROPEL propel;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float minLimitOfFly;

    private void Move()
    {
        if (transform.position.y <= 0) // 지면보다 밑으로 가면 그대로 함수 종료
            return;

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector3.forward * z * moveSpeed * Time.deltaTime); // 앞뒤 이동은 벡터3의 앞방향에 속도와 델타타임 곱한값으로
        transform.Rotate(Vector3.up, x * rotationSpeed * Time.deltaTime);// 회전은 위방향
    }
    private void Fly()
    {
        if (Input.GetButton("Jump"))
        {
            propel.SpeedUp(); // 프로펠 스크립트에 스피드업 함수
        }
        else
        {
            propel.SpeedDown();// 프로펠 스크립트에 스피드다운 함수
        }

        transform.Translate(Vector3.up * (propel.RotationSpeed - minLimitOfFly) / 100 * Time.deltaTime);// translate로 위치 이동 구현

        float posY = Mathf.Clamp(transform.position.y, 0, 50);// 위치 이동 제한 (제한할대상,최소치,최대치)
        transform.position = new Vector3(transform.position.x, posY, transform.position.z);// 위치 특정? -> x y z 좌표로.
    }

    private void Update()
    {
        Move();
        Fly();
    }
}
