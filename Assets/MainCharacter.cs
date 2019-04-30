using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;

        // ワールド座標を基準に、回転を取得
        // Vector3 worldAngle = myTransform.eulerAngles;
        // float world_angle_x = worldAngle.x; // ワールド座標を基準にした、x軸を軸にした回転角度
        // float world_angle_y = worldAngle.y; // ワールド座標を基準にした、y軸を軸にした回転角度
        // float world_angle_z = worldAngle.z; // ワールド座標を基準にした、z軸を軸にした回転角度
        // Debug.Log(world_angle_z);

        // ワールド座標を基準に、回転を取得

        Vector3 worldAngle = myTransform.eulerAngles;
        // worldAngle.x = 10.0f + worldAngle.x; // ワールド座標を基準に、x軸を軸にした回転を10度に変更
        // worldAngle.y = 10.0f; // ワールド座標を基準に、y軸を軸にした回転を10度に変更
        // worldAngle.z = 10.0f; // ワールド座標を基準に、z軸を軸にした回転を10度に変更
        // myTransform.eulerAngles = worldAngle; // 回転角度を設定
        myTransform.Rotate (5.0f, 0f, 0f);

    }
}
