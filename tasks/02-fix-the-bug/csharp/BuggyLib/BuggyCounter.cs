using System.Threading;

namespace BuggyLib;

public static class BuggyCounter
{
    private static long _current = 0;
    private static object _lock = new object();

    public static long NextId()
    {
        lock (_lock)
        {
            long value = _current;
            Thread.Sleep(0);
            _current++;
            return value;
        }
    }
}
