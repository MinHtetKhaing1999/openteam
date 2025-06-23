using System.Threading;

namespace BuggyLib;

public static class BuggyCounter
{
    private static long _current = 0;
    private static object _lock = new object();

    public static long NextId()
    {
        // the reason to the race condition is that the increment method is being called
        // from the parallel threads without any synchronization.
        // we often use a lock to ensure that only one thread can access the critical section at a time.
        lock (_lock)
        {
            long value = _current;
            Thread.Sleep(0);
            _current++;
            return value;
        }
    }
}
