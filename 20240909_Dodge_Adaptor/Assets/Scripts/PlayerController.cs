using UnityEngine;
using UnityEngine.Events;

// 컴포넌트 : 게임오브젝트의 기능을 담당하는 부품
public class PlayerController : MonoBehaviour
{
    // 인스펙터 창에서 참조하거나 값을 지정해주어서 쓰는 경우
    // 맴버변수 : 정보
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
        if (moveDir.sqrMagnitude > 1)  // magnitude : 백터의 크기 / sqrMagnitude : 벡터의 크기의 제곱, 루트 계산을 진행하지 않음(최적화에 더 좋음)
        {
            moveDir.Normalize();// 제곱이 1을 넘으면 : 원점에서의 거리가 1이상이면 // 정규화 진행
        }

        rigidPlayer.velocity = moveDir * moveSpeed;
    }

    public void TakeHit()
    {
        OnDied?.Invoke();// 온다이드 이벤트? 호출
        Destroy(gameObject); // 오브젝트 삭제
    }

    // 
    //
    //이 부분 잘 모르겠습니다 ㅠ
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
