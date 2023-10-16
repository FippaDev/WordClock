using System;
using System.Threading;
using System.Windows.Forms;

namespace WordClock
{
	public partial class ClockForm : Form
	{
		private static readonly WordFlags WordFlags = new WordFlags();
		private Controller _controller;
		private FormDisplay _display;
		private Thread _controllerThread;
		private Thread _displayThread;

		public ClockForm()
		{
			InitializeComponent();
		}

		private void Form1Load(object sender, EventArgs e)
		{
			_controller = new Controller(WordFlags);
			_display = new FormDisplay(WordFlags, this);
			_controllerThread = new Thread(_controller.ThreadMethod);
			_displayThread = new Thread(_display.ThreadMethod);

			_controllerThread.Start();
			_displayThread.Start();
		}

		private void ClockFormFormClosing(object sender, FormClosingEventArgs e)
		{
			_controllerThread.Abort();
			_displayThread.Abort();
		}
	}
}