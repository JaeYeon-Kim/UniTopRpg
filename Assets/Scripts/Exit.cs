using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 출입구 위치
public enum ExitDirection
{
    right,  // 오른쪽 
    left,   // 왼쪽 
    down,   // 아래쪽
    up      // 위쪽 
}

// 출입구 관련 스크립트 
public class Exit : MonoBehaviour
{
    public string sceneName = "";   // 이동할 씬 이름 
    public int doorNumber = 0;  // 문번호 
    public ExitDirection direction = ExitDirection.down;        // 문의 위치 : 플레이어 캐릭터가 출입구에서 나왔을때 바라보는 방향 


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Player 태그를 가진 게임 오브젝트와 접촉하면 씬을 이동 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            RoomManager.ChangeScene(sceneName, doorNumber);
        }
    }
}
