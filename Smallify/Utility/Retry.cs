using NLog;
using System;
using System.Threading.Tasks;

namespace Smallify.Utility
{
	public static class Retry
	{
		private static Logger GetLogger = LogManager.GetCurrentClassLogger();

		public static void AttemptWithRetries<T>(int attempts, TimeSpan delay, Action action) where T:Exception
		{
			var retry = 0;
			do
			{
				try
				{
					retry++;
					action();

					GetLogger.Info("[RETRY] Attempt {0} - {1}: Completed", retry.ToString(), action.Method.Name);
					Console.WriteLine("[RETRY] Attempt {0} - {1}: Completed", retry.ToString(), action.Method.Name);
					break;
				}
				catch (T ex)
				{
					GetLogger.Error(ex, "[RETRY] Attempt {0} - {1}: {2}", retry.ToString(), action.Method.Name , ex.Message);
					Console.WriteLine("[RETRY] Attempt {0} - {1}: {2}", retry.ToString(), action.Method.Name, ex.Message);

					if (retry >= attempts)
					{
						throw;
					}

					Task.Delay(delay).Wait();
				}
			} while (true);
		}

		private static async Task<T> This<T>(Func<T> func, int retryCount)
		{
			try
			{
				var result = await Task.Run(func);
				return result;
			}
			catch when (retryCount-- > 0)
			{

			}
			return await This(func, retryCount);
		}
	}
}
