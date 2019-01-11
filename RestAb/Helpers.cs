using System;
using System.Collections.Generic;

namespace RestAb
{

  /// <summary> Static Helper's class </summary>
  public static class Helpers
  {
    private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    /// <summary> returms <see cref="time"/> timestamp </summary>
    public static long Timestamp(DateTime time)
    {
      TimeSpan elapsedTime = time - Epoch;
      return (long)elapsedTime.TotalSeconds;
    }

    /// <summary> returms string <see cref="time"/> timestamp </summary>
    public static string TimestampStr(DateTime time)
    {
      return Timestamp(time).ToString();
    }

    /// <summary> returns Dictionary[char, count] for <see cref="hash"/> string </summary>
    public static Dictionary<char, int> GetHashChart(string hash)
    {
      return GetChart(hash, CreateEmptyHashCharDictionary());
    }

    /// <summary> returns Dictionary[char, count] for string </summary>
    public static Dictionary<char, int> GetChart(string str, Dictionary<char, int> dict = null)
    {
      dict = dict ?? new Dictionary<char, int>(16);
      if (str != null)
        foreach (var ch in str)
        {
          dict.TryGetValue(ch, out int currentCount);
          dict[ch] = currentCount + 1;
        }
      return dict;
    }

    /// <summary> 
    /// create and return Empty HashCharDictionary
    /// hexadecimal predefined, case invariant
    /// </summary>
    public static Dictionary<char, int> CreateEmptyHashCharDictionary()
    {
      var dict = new Dictionary<char, int>(InvariantCharEquarer.Instance);
      for (int i = 0; i < 10; i++)
      {
        char c = i.ToString()[0];
        dict.Add(c, 0);
      }
      for (int i = 10; i < 16; i++)
      {
        char c = (Char)('A' + i - 10);
        dict.Add(c, 0);
      }
      return dict;
    }

    /// <summary> Helper case invariant Char <see cref="IEqualityComparer"/> </summary>
    public class InvariantCharEquarer : IEqualityComparer<Char>
    {
      public static IEqualityComparer<Char> Instance = new InvariantCharEquarer();

      public bool Equals(char x, char y)
      {
        return Char.ToUpperInvariant(x) == Char.ToUpperInvariant(x);
      }

      public int GetHashCode(char ch)
      {
        return Char.ToUpperInvariant(ch).GetHashCode();
      }
    }
  }

}
