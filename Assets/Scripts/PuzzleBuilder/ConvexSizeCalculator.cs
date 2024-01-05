namespace PuzzleBuilder
{
    public class ConvexSizeCalculator
    {
        public float GetConvexSize(float minSize, float maxSize)
        {
            return (maxSize - minSize) / 2;
        }
    }
}

