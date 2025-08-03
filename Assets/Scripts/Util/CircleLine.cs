using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(LineRenderer))]
public class CircleRenderer : MonoBehaviour
{
    public float radius = 1.0f;
    public int segments = 50;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        DrawCircle();
    }

    void DrawCircle()
    {
        lineRenderer.positionCount = segments + 1;

        for (int i = 0; i <= segments; i++)
        {
            float angle = (float)i / segments * 2 * Mathf.PI;
            float x = radius * Mathf.Cos(angle);
            float z = radius * Mathf.Sin(angle);


            Vector3 point = transform.position + new Vector3(x, 0, z);
            lineRenderer.SetPosition(i, point);
        }
    }
}
