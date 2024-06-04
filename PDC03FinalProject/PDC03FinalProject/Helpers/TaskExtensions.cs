using System;
using System.Threading.Tasks;

namespace PDC03FinalProject.Helpers
{
    public static class TaskExtensions
    {
        public static void SafeFireAndForget(this Task task, bool continueOnCapturedContext, Action<Exception> onException = null)
        {
            task.ContinueWith(t =>
            {
                if (t.IsFaulted && t.Exception != null)
                {
                    onException?.Invoke(t.Exception);
                }
            }, continueOnCapturedContext ? TaskContinuationOptions.ExecuteSynchronously : TaskContinuationOptions.None);
        }
    }
}
