using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


/*
화살제어 스크립트 
*/
public class ArrowController : MonoBehaviour
{
    public float deleteTime = 2;    // 제거 시간 
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, deleteTime);        // 일정 시간 후 제거하기(2초)
    }

    // 게임 오브젝트에 접촉 
    private void OnCollisionEnter2D(Collision2D collision) {
        
        // 접촉한 게임 오브젝트의 자식으로 설정하기 
        transform.SetParent(collision.transform);

        // 아래와 같은 처리로 꽂힌듯한 효과를 준다. 

        // 충돌 판정을 비활성
        GetComponent<CircleCollider2D>().enabled = false;

        // 물리 시뮬레이션 비활성 
        GetComponent<Rigidbody2D>().simulated = false;
    }
}
