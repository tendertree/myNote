/*
* hollow 방식으로 삼각형 채우기 
*/
int[] DrawHollowTriangles(Vector3[] points)
{
    int sides = points.Length / 2;
    int triangleAmount = sides * 2;
    List<int> newTriangles = new List<int>();
    for (int i = 0; i < sides; i++)
    {
        int outerIndex = i;
        int innerIndex = i + sides;


        newTriangles.Add(outerIndex);
        newTriangles.Add(innerIndex);
        newTriangles.Add((i + 1) % sides);

        newTriangles.Add(outerIndex);
        newTriangles.Add(sides + ((sides + i - 1) % sides));
        newTriangles.Add((outerIndex + sides));
    }
}
/* 
 * mesh에 point증가 
 */
public void DrawHollow(int sides, float outerRadius, float innerRadius)
{
    List<vector3> pointsList = new List<Vector3>();
    List<vector3> outerPoints = GetCircumferencePoints(sides, outerRadius);
    pointsList.AddRange(outerPoints);
    List<vector3> innerPoints = GetCircumferencePoints(sides, innerRadius);
    pointsList.AddRange(innerPoints);

    polygonPoints = pointsList.ToArray();
    polygonTriangles = DrawHoolowTriangles(polygonPotins);
    mesh.Clear();
    mesh.vertices = polygonPotins;
    mesh.triangles = polygonTriangles;
}
