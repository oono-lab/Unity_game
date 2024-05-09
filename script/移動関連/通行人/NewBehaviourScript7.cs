using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript7 : MonoBehaviour
{
    // Start is called before the first frame update
    public string OtherObject = "OtherObject";
    public string humanObject = "humanObject";


    public float referenceX = 0.0f;

    
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        HandleCollision(collision);
    }

    void HandleCollision(Collision collision)
    {
        // 衝突した対象が他のオブジェクトである場合
        if (collision.gameObject.CompareTag(OtherObject))
        {
            Vector3 collisionNormal = collision.contacts[0].normal;
            if (Vector3.Dot(collisionNormal, transform.forward) < -0.9f)
            {
                float currentX = transform.position.x;

                if (currentX <= referenceX)
                {
                    // 左にずらす
                    ShiftObject(-1.0f);
                }
                else
                {
                    // 右にずらす
                    ShiftObject(1.0f);
                }
            }
        }

        else if (collision.gameObject.CompareTag(humanObject))
        {
            Vector3 collisionNormal = collision.contacts[0].normal;
            if (Vector3.Dot(collisionNormal, transform.forward) < -0.9f)
            {
                float currentX = transform.position.x;

                if (currentX <= referenceX)
                {
                    // 左にずらす
                    ShiftObject(-1.0f);
                }
                else
                {
                    // 右にずらす
                    ShiftObject(1.0f);
                }
            }
        }
        else
        {
            return;
        }
    }

    void ShiftObject(float direction)
    {
        // 移動する方向を指定します
        Vector3 shiftDirection = transform.right * direction;

        // 移動する距離を指定します
        float shiftAmount = 1.0f;

        // 次のフレームでの位置を計算します
        Vector3 nextPosition = transform.position + shiftDirection * shiftAmount;

        // 次のフレームで位置を更新します
        StartCoroutine(MoveToObject(nextPosition));
    }

    IEnumerator MoveToObject(Vector3 targetPosition)
    {
        float duration = 0.5f; // 移動にかかる時間（秒）
        float elapsedTime = 0f;
        Vector3 startingPosition = transform.position;

        // 指定した時間内に移動させる
        while (elapsedTime < duration)
        {   
            transform.position = Vector3.Lerp(startingPosition, targetPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 最終的な位置を設定
        transform.position = targetPosition;
        
        
    }
}
