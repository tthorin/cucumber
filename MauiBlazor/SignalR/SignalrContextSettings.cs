using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazor.SignalR
{
	internal class SignalrContextSettings
	{
		public string Url { get; set; }
		public string Room { get; set; }
		public string Username { get; set; }
	}
}
