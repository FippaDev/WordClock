using System;
using System.Threading;

namespace WordClock
{
	internal class Display
	{
		protected readonly WordFlags WordFlags;

		protected static short Off = 0;
		protected static short Lo = 60;//%
		protected static short Med = 80;//%
		protected static short Hi = 100;//%

		protected static short[] Intensity = new[]
		                                    	{
		                                    		Lo, Lo, Lo, Lo, Lo, Lo, Lo, Med, Med, Med, Med, Med, Med, Med, Med, Med, Med, Med, Hi, Hi,
		                                    		Hi, Med, Med, Med
		                                    	};

		public Display(WordFlags wordFlags)
		{
			WordFlags = wordFlags;
		}

		public void ThreadMethod()
		{
			while (true)
			{
				DisplayTime(WordFlags.Now);
				Thread.Sleep(250);
			}
		}

		internal virtual void DisplayTime(DateTime newTime)
		{
			throw new NotImplementedException("TODO in the derived class");
		}
	}
}