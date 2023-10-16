using System;
using System.Drawing;

namespace WordClock
{
	internal class FormDisplay : Display
	{
		private readonly ClockForm _clockForm;
		private static readonly Color OffColor = Color.DarkSlateGray;

		internal FormDisplay(WordFlags wordFlags, ClockForm clockForm)
			: base(wordFlags)
		{
			_clockForm = clockForm;
			Display(WordFlags, Off);
		}

		internal override void  DisplayTime(DateTime newTime)
		{
			WordFlags flags = WordFlags.GetFlagsForDisplay();
			short intensity = Convert.ToInt16((Intensity[newTime.Hour] / 100.0) * 255);
			Display(flags, intensity);
		}

		private void Display(WordFlags flags, short intensity)
		{
			Color c = Color.FromArgb(intensity, intensity, intensity);
			_clockForm.labelItIs.ForeColor = c;
			_clockForm.labelTwenty.ForeColor = (flags.Twenty && intensity != 0) ? c : OffColor;
			_clockForm.labelFive2.ForeColor = (flags.Five2 && intensity != 0) ? c : OffColor;
			_clockForm.labelTen2.ForeColor = (flags.Ten2 && intensity != 0) ? c : OffColor;
			_clockForm.labelQuarter.ForeColor = (flags.Quarter && intensity != 0) ? c : OffColor;
			_clockForm.labelHalf.ForeColor = (flags.Half && intensity != 0) ? c : OffColor;
			_clockForm.labelPast.ForeColor = (flags.Past && intensity != 0) ? c : OffColor;
			_clockForm.labelTo.ForeColor = (flags.To && intensity != 0) ? c : OffColor;
			_clockForm.labelOne.ForeColor = (flags.One && intensity != 0) ? c : OffColor;
			_clockForm.labelTwo.ForeColor = (flags.Two && intensity != 0) ? c : OffColor;
			_clockForm.labelThree.ForeColor = (flags.Three && intensity != 0) ? c : OffColor;
			_clockForm.labelFour.ForeColor = (flags.Four && intensity != 0) ? c : OffColor;
			_clockForm.labelFive.ForeColor = (flags.Five && intensity != 0) ? c : OffColor;
			_clockForm.labelSix.ForeColor = (flags.Six && intensity != 0) ? c : OffColor;
			_clockForm.labelSeven.ForeColor = (flags.Seven && intensity != 0) ? c : OffColor;
			_clockForm.labelEight.ForeColor = (flags.Eight && intensity != 0) ? c : OffColor;
			_clockForm.labelNine.ForeColor = (flags.Nine && intensity != 0) ? c : OffColor;
			_clockForm.labelTen.ForeColor = (flags.Ten && intensity != 0) ? c : OffColor;
			_clockForm.labelEleven.ForeColor = (flags.Eleven && intensity != 0) ? c : OffColor;
			_clockForm.labelTwelve.ForeColor = (flags.Twelve && intensity != 0) ? c : OffColor;
			_clockForm.labelOClock.ForeColor = (flags.OClock && intensity != 0) ? c : OffColor;
			_clockForm.labelMinutes.ForeColor = (flags.Minutes && intensity != 0) ? c : OffColor;
		}
	}
}
