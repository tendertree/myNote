/*
 *   원형으로 vertex 생성 
 */
List<Vector3> GetCircumferencePoints(int sides, float radius)
{
    List<Vector3> points = new List<Vector3>();
    float circumferenceProgressPerStep = (float)1 / sides;
    float TAU = 2 * Mathf.PI;
    float radianProgressPerStep = circumferenceProgressPerStep * TAU;
    for (int i = 0; i < sides; i++)
    {
        float currentRadian = radianProgreesPerStep * i;
        points.Add(new Vector3(Mathf.Cos(currentRadian) * radius, Mathf.Sin(currentRadian) * radius, 0));
    }
    return points;
}

void DrawFilled(int sides, flaot radius)
{
    polygonPoints = GetCircumferendePoints(sides, radius).ToArray();
    polygonTriangles = DrawFilledTriangles(polygonPoitns);
    mesh.Clear();
    mesh.vertices = polygonPoints;
    mesh.triangles = polygonTriangles;
}
/*
 *  삼각형으로 채움 
 */
int[] DrawFilledTriangles(Vector3[] points)
{
    int triangleAmount = points.Length - 2;
    List<int> newTriangles = new List<int>();
    for (int i = 0; i < triangleAmount; i++)
    {
        newTriangles.Add(0);
        newTriangles.Add(i + 2);
        newTriangles.Add(i + 1);
    }
}

