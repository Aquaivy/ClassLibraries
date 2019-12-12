using UnityEngine;
using System.Collections;
using System.Collections.Generic;


// 创建自定义Mesh类
public class CreateMesh : MonoBehaviour
{


    /// <summary>
    /// 生成自定义多边形方法
    /// </summary>
    /// <param name="s_Vertives">自定义的顶点数组</param>
    public void DoCreatPloygonMesh(Vector3[] s_Vertives)
    {
        //新建一个空物体进行进行绘制自定义多边形
        GameObject tPolygon = new GameObject("tPolygon");

        //绘制所必须的两个组件
        tPolygon.AddComponent<MeshFilter>();
        tPolygon.AddComponent<MeshRenderer>();

        //新申请一个Mesh网格
        Mesh tMesh = new Mesh();

        //存储所有的顶点
        Vector3[] tVertices = s_Vertives;

        //存储画所有三角形的点排序
        List<int> tTriangles = new List<int>();

        //根据所有顶点填充点排序
        for (int i = 0; i < tVertices.Length - 1; i++)
        {
            tTriangles.Add(i);
            tTriangles.Add(i + 1);
            tTriangles.Add(tVertices.Length - i - 1);
        }

        //赋值多边形顶点
        tMesh.vertices = tVertices;

        //赋值三角形点排序
        tMesh.triangles = tTriangles.ToArray();

        //重新设置UV，法线
        tMesh.RecalculateBounds();
        tMesh.RecalculateNormals();

        //将绘制好的Mesh赋值
        tPolygon.GetComponent<MeshFilter>().mesh = tMesh;

    }

}