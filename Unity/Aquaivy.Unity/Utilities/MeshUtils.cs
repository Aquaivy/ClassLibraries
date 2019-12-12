using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Aquaivy.Unity.Utilities
{
    /// <summary>
    /// Mesh的表面积、体积计算
    /// </summary>
    public static class MeshUtils
    {
        /// <summary>
        /// 计算Mesh的面积
        /// </summary>
        /// <param name="meshFilter"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        private static float CalculateMeshArea(MeshFilter meshFilter, Vector3 scale)
        {
            Vector3[] vertices = meshFilter.mesh.vertices;
            //int[] arrTriangles = meshFilter.mesh.triangles;
            float area = 0.0f;
            for (int i = 0; i < meshFilter.mesh.subMeshCount; i++)
            {
                int[] arrIndices = meshFilter.mesh.GetTriangles(i);
                for (int j = 0; j < arrIndices.Length; j += 3)
                {
                    area += CalculateTriangleArea(vertices[arrIndices[j]], vertices[arrIndices[j + 1]], vertices[arrIndices[j + 2]], scale);
                }
            }

            //Debug.Log("Area = " + area);

            return area;
        }

        /// <summary>
        /// 计算三角形面积
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        private static float CalculateTriangleArea(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 scale)
        {
            p0 = new Vector3(p0.x * scale.x, p0.y * scale.y, p0.z * scale.z);
            p1 = new Vector3(p1.x * scale.x, p1.y * scale.y, p1.z * scale.z);
            p2 = new Vector3(p2.x * scale.x, p2.y * scale.y, p2.z * scale.z);

            float a = (p1 - p0).magnitude;
            float b = (p2 - p1).magnitude;
            float c = (p0 - p2).magnitude;
            float p = (a + b + c) * 0.5f;

            return Mathf.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        /// <summary>
        /// 计算Mesh的体积
        /// </summary>
        /// <param name="meshFilter"></param>
        /// <param name="scale"></param>
        private static void CalculateMeshVolume(MeshFilter meshFilter, Vector3 scale)
        {
            Vector3[] arrVertices = meshFilter.mesh.vertices;
            //int[] arrTriangles = meshFilter.mesh.triangles;
            float volume = 0.0f;
            for (int i = 0; i < meshFilter.mesh.subMeshCount; i++)
            {
                int[] arrIndices = meshFilter.mesh.GetTriangles(i);
                for (int j = 0; j < arrIndices.Length; j += 3)
                {
                    volume += CalculateVolume(arrVertices[arrIndices[j]]
                                , arrVertices[arrIndices[j + 1]]
                                , arrVertices[arrIndices[j + 2]],
                                scale);
                }
            }


            Debug.Log("Volume= " + Mathf.Abs(volume));
        }

        private static float CalculateVolume(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 scale)
        {
            p0 = new Vector3(p0.x * scale.x, p0.y * scale.y, p0.z * scale.z);
            p1 = new Vector3(p1.x * scale.x, p1.y * scale.y, p1.z * scale.z);
            p2 = new Vector3(p2.x * scale.x, p2.y * scale.y, p2.z * scale.z);

            float v321 = p2.x * p1.y * p0.z;
            float v231 = p1.x * p2.y * p0.z;
            float v312 = p2.x * p0.y * p1.z;
            float v132 = p0.x * p2.y * p1.z;
            float v213 = p1.x * p0.y * p2.z;
            float v123 = p0.x * p1.y * p2.z;

            return (1.0f / 6.0f) * (-v321 + v231 + v312 - v132 - v213 + v123);
        }
    }
}
