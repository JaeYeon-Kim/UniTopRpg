using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
플레이어를 따라다니는 카메라 
*/
public class CameraManager : MonoBehaviour
{

    private void Update() {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // 플레이어의 위치 연동
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        }
    }
}
