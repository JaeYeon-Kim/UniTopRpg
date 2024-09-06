using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
화살 발사 스크립트 
*/
public class ArrowShoot : MonoBehaviour
{
    public float shootSpeed = 12.0f; // 화살 속도 
    public float shootDelay = 0.25f; // 발사 딜레이 

    [SerializeField] private GameObject bowPrefab;  // 활 프리팹
    [SerializeField] private GameObject arrowPrefab;    // 화살 프리팹 

    bool inAttack = false;  // 공격 중 여부 
    GameObject bowObj;      // 활의 게임 오브젝트      
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = transform.position;
        // 활을 플레이어에 배치 
        bowObj = Instantiate(bowPrefab, pos, Quaternion.identity);
        bowObj.transform.SetParent(transform);  // 플레이어 캐릭터를 활의 부모로 설정 
    }

    // Update is called once per frame
    void Update()
    {
        // 공격키를 누를 경우 공격 
        if (Input.GetButtonDown("Fire3"))
        {
            // 공격 키가 눌림
            Attack();
        }

        // 활의 회전과 우선순위
        float bowZ = -1;    // 활의 Z값(캐릭터보다 앞으로 설정)
        PlayerController plmv = GetComponent<PlayerController>();
        if (plmv.angleZ > 30 && plmv.angleZ < 150)
        {
            // 위 방향
            bowZ = 1;       // 활의 Z 값(캐릭터보다 뒤로 설정)
        }

        // 활의 회전
        bowObj.transform.rotation = Quaternion.Euler(0, 0, plmv.angleZ);

        // 활의 우선 순위 
        bowObj.transform.position = new Vector3(transform.position.x, transform.position.y, bowZ);
    }

    // 공격 
    public void Attack()
    {
        // 화살을 가지고 있음 & 공격 중이 아님
        if (ItemKeeper.hasArrows > 0 && inAttack == false)
        {
            ItemKeeper.hasArrows -= 1;  // 화살을 소모 
            inAttack = true;

            // 화살 발사 
            PlayerController playerCnt = GetComponent<PlayerController>();
            float angleZ = playerCnt.angleZ;    // 회전 각도 

            // 화살의 게임오브젝트 만들기(진행 방향으로 회전)
            Quaternion r = Quaternion.Euler(0, 0, angleZ);
            GameObject arrowObj = Instantiate(arrowPrefab, transform.position, r);

            // 화살을 발사할 벡터 생성
            float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
            float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);
            Vector3 v = new Vector3(x, y) * shootSpeed;

            // 화살에 힘을 가하기
            Rigidbody2D body = arrowObj.GetComponent<Rigidbody2D>();
            body.AddForce(v, ForceMode2D.Impulse);
            
            // 공격중이 아님으로 설정
            Invoke("StopAttack", shootDelay);

        }
    }

    // 공격 중지 
    public void StopAttack()
    {
        inAttack = false;
    }
}
