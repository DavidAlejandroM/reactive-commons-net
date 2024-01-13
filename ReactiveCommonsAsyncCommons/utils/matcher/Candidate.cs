namespace ReactiveCommonsAsyncCommons.utils.matcher;

public class Candidate : IComparable<Candidate>, IComparer<Candidate>
{
    public string Key { get; }
    public long Score { get; }

    public Candidate(string key, long score)
    {
        Key = key;
        Score = score;
    }

    public int CompareTo(Candidate other)
    {
        return Score.CompareTo(other.Score);
    }

    public int Compare(Candidate x, Candidate y)
    {
        return x.Score.CompareTo(y.Score);
    }

    public override bool Equals(object obj)
    {
        return obj is Candidate other && Key == other.Key && Score == other.Score;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Key, Score);
    }

    public override string ToString()
    {
        return $"Candidate(key={Key}, score={Score})";
    }
}