using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCamController : MonoBehaviour
 {
    int width = 1920;
    int height = 1080;
    int fps = 30;
    WebCamTexture webcamTexture;
    Vector3 basePos = Vector3.zero;

    void Start () {
        WebCamDevice[] devices = WebCamTexture.devices;
        webcamTexture = new WebCamTexture(devices[0].name, this.width, this.height, this.fps);
        GetComponent<Renderer> ().material.mainTexture = webcamTexture;
        webcamTexture.Play();
        basePos = transform.position;



    }
    void Update()
    {
                  // VR.InputTracking から hmd の位置を取得
       var trackingPos = UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye);

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
       Debug.Log(transform.GetChild(0).position);

    }
}