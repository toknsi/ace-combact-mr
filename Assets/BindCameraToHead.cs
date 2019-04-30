using UnityEngine;

public class BindCameraToHead : MonoBehaviour
{
    Vector3 basePos = Vector3.zero;

    void Start()
    {
        basePos = transform.position;
    }
    void Update()
    {
        // VR.InputTracking から hmd の位置を取得
        var trackingPos = UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye);

        var trackingRotation = UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye);
        var scale = transform.localScale;
        trackingPos = new Vector3(
            trackingPos.x * scale.x,
            trackingPos.y * scale.y,
            trackingPos.z * scale.z
        );

        // 回転
        trackingPos = transform.rotation * trackingPos;

        // 固定したい位置から hmd の位置を
        // 差し引いて実質 hmd の移動を無効化する
        transform.position = basePos - trackingPos;

        // 子のカメラの座標がbasePosと同じ値になるかを確認する
        // Debug.Log(transform.GetChild(0).position);
        Transform myTransform = this.transform;
        myTransform.Rotate(trackingRotation.x, trackingRotation.y, trackingRotation.z);

    }
}