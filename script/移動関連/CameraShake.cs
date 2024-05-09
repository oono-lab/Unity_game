using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform cameraTransform; // カメラのTransform
    public float shakeDuration = 0.5f; // 揺れの時間
    public float shakeMagnitude = 0.5f; // 揺れの強さ

    private float initialPositionY; // 初期のY座標
    private float shakeDurationRemaining = 0f; // 残りの揺れ時間
    private Vector3 originalPosition; // カメラの初期位置

    void Awake()
    {
        if (cameraTransform == null)
        {
            cameraTransform = GetComponent<Transform>(); // カメラのTransformが設定されていない場合、自動的に取得
        }
    }

    void Start()
    {
        originalPosition = cameraTransform.localPosition; // カメラの初期位置を保存
        initialPositionY = originalPosition.y; // Y座標の初期位置を保存
    }

    void Update()
    {
        if (shakeDurationRemaining > 0)
        {
            // カメラをランダムに揺らす
            float offsetY = Random.Range(-shakeMagnitude, shakeMagnitude);
            Vector3 randomOffset = new Vector3(0f, offsetY, 0f);

            // 残りの揺れ時間を減らす
            shakeDurationRemaining -= Time.deltaTime;
        }
        else
        {
            // 揺れが終了したら、カメラの位置を初期位置に戻す
            cameraTransform.localPosition = originalPosition;
        }
    }

    public void Shake()
    {
        shakeDurationRemaining = shakeDuration; // 揺れの時間を設定
    }
}
