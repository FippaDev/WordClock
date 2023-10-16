using System;
using System.Threading;

namespace WordClock
{
	class Controller
	{
		private readonly WordFlags _wordFlags;

		public Controller(WordFlags wordFlags)
		{
			_wordFlags = wordFlags;
			wordFlags.Now = new DateTime(2012, 02, 29, 21, 30, 0);
		}

		public void ThreadMethod()
		{	
			while(true)
			{
				_wordFlags.SetFlags(_wordFlags.Now);
				Thread.Sleep(200);
				_wordFlags.Now = _wordFlags.Now.AddMinutes(1);
			}			
		}
	}
}
