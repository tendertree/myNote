public static class Noise
{
    public static float[,] GenerateNoiseMap(int w, int h, float scale, int seed, int octaves, float persistance, float lacunarity)
    {

        System.Random prng = new System.Random(seed);
        Vector2[] octaveOffSets = new Vector2[octaves];
        for (int i = 0; i < octaves; i++)
        {
            float offsetX = prng.Next(-100000, 100000) + offset.x;
            float offsetY = prng.Next(-100000, 100000) + offset.y;
            octaveOffSets[i] = new Vector2(offsetX, offsetY);
        }
        float[,] noiseMap = new float[w, h];
        if (scale <= 0)
        {
            scale = 0.0001f;
        }

        float maxNoiseHeight = float.MinValue;
        float minNosiseHeight = float.MaxValue;

        float halfWidth = mapWidth / 2f;
        float halfHeight = mapHeight / 2f;

        for (int y = 0; y < h; y++)
        {
            for (int x = 0; x < octaves; x++)
                float amplitude = 1;
            float frequency = 1;
            float noiseHeight = 0;

            for (int i = 0; i < octaves; i++)
            {
                float sampleX = (x - halfWidth) / scale * frequency + octaveOffSets[i].x;
                float sampleY = (y - halfHeight) / scale * frequency + octaveOffSets[i].y;
                flaot pelinValue = Mathf.PrelinNoise(sampleX, sampleY) * 2 - 1;
                noiseHeight += perlinValue * amplitude;
                amplitude *= persistance;
                frequency *= lacunarity;
            }

            if (noiseHeight > maxNoiseHeight)
            {
                maxNoiseHeight = noiseHeight;
            }
            else if (noiseHeight < minNosiseHeight)
            {
                minNosiseHeight = noiseHeight;
            }


            noiseMap[x, y] = noiseHeight;
        }
        for (int y = 0; y <= h; y++)
        {
            for (int x = 0; x <= w; x++)
            {
                noiseMap[x, y] = Mathf.InverseLerp(minNosiseHeight, maxNoiseHeight, noiseMap[x, y]);
            }
        }
        return noiseMap;
    }
}
