using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//获取组成多变形点类
public class GetEnterPoints : MonoBehaviour
{
    //存储手动获取到的多边形点列表
    private List<Vector3> m_enterPoints = new List<Vector3>();

    // Update is called once per frame
    void Update()
    {

        //左键取点
        if (Input.GetMouseButtonDown(0))
        {
            //屏幕位置转射线
            Ray tRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            //射线返回点信息
            RaycastHit tHit;
            //发射射线
            if (Physics.Raycast(tRay, out tHit))
            {
                //如果打在地面上，则将点存储起来
                if (tHit.transform.tag == "Ground")
                {
                    //这里为了形成的面不与原先底板重合，提升了一个高度
                    m_enterPoints.Add(tHit.point + new Vector3(0, 0.01f, 0));
                }
            }
        }

        //右键形成面
        if (Input.GetMouseButtonDown(1))
        {
            //形成面至少三点
            if (m_enterPoints.Count > 2)
            {
                //调用形成多变形方法
                CreateMesh tCreatMesh = new CreateMesh();
                tCreatMesh.DoCreatPloygonMesh(m_enterPoints.ToArray());

                //每次绘制完清空手动获取的点列表
                m_enterPoints.Clear();

            }

        }

    }
}