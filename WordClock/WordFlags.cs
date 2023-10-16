using System;

namespace WordClock
{
	internal class WordFlags
	{
		private readonly object _timeLock = new object();

		public DateTime Now;

		public bool One;
		public bool Two;
		public bool Three;
		public bool Four;
		public bool Five;
		public bool Six;
		public bool Seven;
		public bool Eight;
		public bool Nine;
		public bool Ten;
		public bool Eleven;
		public bool Twelve;
		public bool Past;
		public bool To;
		public bool OClock;
		public bool Quarter;
		public bool Five2;
		public bool Ten2;
		public bool Twenty;
		public bool Half;
		public bool Minutes;

		internal void SetFlags(DateTime newTime)
		{
			lock (_timeLock)
			{
				One = Two = Three = Four = Five = Six = Seven = Eight = Nine = Ten = Eleven = Twelve = false;
				Past = To = OClock = Quarter = Five2 = Ten2 = Twenty = Half = Minutes = false;
				SetOtherFlags(newTime);
			}
		}

		private void SetHourFlag(int hour)
		{
			switch (hour)
			{
				case 1:
				case 13:
					One = true;
					break;
				case 2:
				case 14:
					Two = true;
					break;
				case 3:
				case 15:
					Three = true;
					break;
				case 4:
				case 16:
					Four = true;
					break;
				case 5:
				case 17:
					Five = true;
					break;
				case 6:
				case 18:
					Six = true;
					break;
				case 7:
				case 19:
					Seven = true;
					break;
				case 8:
				case 20:
					Eight = true;
					break;
				case 9:
				case 21:
					Nine = true;
					break;
				case 10:
				case 22:
					Ten = true;
					break;
				case 11:
				case 23:
					Eleven = true;
					break;
				case 0:
				case 12:
				case 24:
					Twelve = true;
					break;
				default:
					throw new NotImplementedException();
			}
		}

		private void SetOtherFlags(DateTime newTime)
		{
			if (newTime.Minute == 0 || newTime.Minute < 5)
			{
				OClock = true;
				SetHourFlag(newTime.Hour);
				return;
			}

			Minutes = true;

			if (newTime.Minute > 4 && newTime.Minute < 10)
			{
				Five2 = Past = true;
				SetHourFlag(newTime.Hour);
			}
			else if (newTime.Minute > 9 && newTime.Minute < 15)
			{
				Ten2 = Past = true;
				SetHourFlag(newTime.Hour);
			}
			else if (newTime.Minute > 14 && newTime.Minute < 20)
			{
				Quarter = Past = true;
				Minutes = false;
				SetHourFlag(newTime.Hour);
			}
			else if (newTime.Minute > 19 && newTime.Minute < 25)
			{
				Twenty = Past = true;
				SetHourFlag(newTime.Hour);
			}
			else if (newTime.Minute > 24 && newTime.Minute < 30)
			{
				Twenty = Five2 = Past = true;
				SetHourFlag(newTime.Hour);
			}
			else if (newTime.Minute > 29 && newTime.Minute < 35)
			{
				Half = Past = true;
				Minutes = false;
				SetHourFlag(newTime.Hour);
			}
			else if (newTime.Minute > 34 && newTime.Minute < 40)
			{
				Twenty = Five2 = To = true;
				SetHourFlag(newTime.Hour + 1);
			}
			else if (newTime.Minute > 39 && newTime.Minute < 45)
			{
				Twenty = To = true;
				SetHourFlag(newTime.Hour + 1);
			}
			else if (newTime.Minute > 44 && newTime.Minute < 50)
			{
				Quarter = To = true;
				Minutes = false;
				SetHourFlag(newTime.Hour + 1);
			}
			else if (newTime.Minute > 49 && newTime.Minute < 55)
			{
				Ten2 = To = true;
				SetHourFlag(newTime.Hour + 1);
			}
			else if (newTime.Minute > 54 && newTime.Minute <= 59)
			{
				Five2 = To = true;
				SetHourFlag(newTime.Hour + 1);
			}
			else
			{
				throw new NotImplementedException();
			}
		}

		internal WordFlags GetFlagsForDisplay()
		{
			lock(_timeLock)
			{
				WordFlags flags = new WordFlags
				                  	{
				                  		One = this.One,
				                  		Two = this.Two,
				                  		Three = this.Three,
				                  		Four = this.Four,
				                  		Five = this.Five,
				                  		Six = this.Six,
				                  		Seven = this.Seven,
				                  		Eight = this.Eight,
				                  		Nine = this.Nine,
				                  		Ten = this.Ten,
				                  		Eleven = this.Eleven,
				                  		Twelve = this.Twelve,
				                  		Past = this.Past,
				                  		To = this.To,
				                  		OClock = this.OClock,
				                  		Quarter = this.Quarter,
				                  		Five2 = this.Five2,
				                  		Ten2 = this.Ten2,
				                  		Twenty = this.Twenty,
				                  		Half = this.Half,
				                  		Minutes = this.Minutes
				                  	};
				return flags;
			}
		}
	}
}