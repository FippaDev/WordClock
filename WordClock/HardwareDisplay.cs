using System;

namespace WordClock
{
	internal class HardwareDisplay : Display
	{
		internal HardwareDisplay(WordFlags wordFlags)
			: base(wordFlags)
		{
			Display(WordFlags, Off);
		}

		internal override void  DisplayTime(DateTime newTime)
		{
			WordFlags flags = WordFlags.GetFlagsForDisplay();
			short pwmIntensity = Convert.ToInt16((Intensity[newTime.Hour] / 100.0) * 255);
			Display(flags, pwmIntensity);
		}

		private void Display(WordFlags flags, short pwmIntensity)
		{
			//set IO bit for labelItIs
			//set IO bit for labelTwenty
			//set IO bit for labelFive2
			//set IO bit for labelTen2
			//set IO bit for labelQuarter
			//set IO bit for labelHalf
			//set IO bit for labelPast
			//set IO bit for labelTo
			//set IO bit for labelOne
			//set IO bit for labelTwo
			//set IO bit for labelThree
			//set IO bit for labelFour
			//set IO bit for labelFive
			//set IO bit for labelSix
			//set IO bit for labelSeven
			//set IO bit for labelEight
			//set IO bit for labelNine
			//set IO bit for labelTen
			//set IO bit for labelEleven
			//set IO bit for labelTwelve
			//set IO bit for labelOClock
			//set IO bit for labelMinutes
		}
	}
}
