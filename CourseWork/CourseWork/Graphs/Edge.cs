namespace CourseWork.Graphs;

public class Edge : IComparable<Edge>
{
    public int Source;
    public int Destination;
    public int Weight;

    public int CompareTo(Edge other)
    {
        return Weight.CompareTo(other.Weight);
    }
}