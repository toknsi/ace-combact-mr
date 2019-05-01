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
        // var trackingPos = UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye);
        // var scale = transform.localScale;

        // trackingPos = new Vector3(
        //     trackingPos.x * scale.x,
        //     trackingPos.y * scale.y,
        //     trackingPos.z * scale.z
        // );

        // // 回転
        // trackingPos = transform.rotation * trackingPos;

        // // 固定したい位置から hmd の位置を
        // // 差し引いて実質 hmd の移動を無効化する
        // transform.position = basePos - trackingPos;

        var trackingRotation = UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye);
        Transform myTransform = this.transform;
        Vector3 worldAngle = myTransform.eulerAngles;
        worldAngle.x = trackingRotation.x * 100; // ローカル座標を基準に、x軸を軸にした回転を10度に変更
        worldAngle.y = trackingRotation.y * 100; // ローカル座標を基準に、y軸を軸にした回転を10度に変更
        worldAngle.z = trackingRotation.z * 100; // ローカル座標を基準に、z軸を軸にした回転を10度に変更
        // Debug.Log(trackingRotation.x);
        // Debug.Log(trackingRotation.y);

        myTransform.eulerAngles = worldAngle; // 回転角度を設定

        // myTransform.Rotate(trackingRotation.x, trackingRotation.y, trackingRotation.z);

    }
}