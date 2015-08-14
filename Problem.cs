using System;
using System.Runtime.CompilerServices;
using System.Diagnostics;

public abstract class Problem
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected static string GetCurrentMethod ()
    {
        StackTrace st = new StackTrace ();
        StackFrame sf = st.GetFrame (1);
        return sf.GetMethod().Name;
    }
    
    protected static void PrintTime(Action task)
    {
        TimeSpan begin = Process.GetCurrentProcess().TotalProcessorTime;
        task();
        TimeSpan end = Process.GetCurrentProcess().TotalProcessorTime;
        Console.WriteLine((end - begin).TotalMilliseconds + "ms");
    }
}

