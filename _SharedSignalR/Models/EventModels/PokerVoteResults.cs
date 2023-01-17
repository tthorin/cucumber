using System;
using System.Collections.Generic;
using System.Text;

namespace _SharedSignalR.Models
{
	public class PokerVoteResults
	{
		public string Room { get; set; } = "";
		public List<PokerVote> Votes { get; set; } = new();
	}
}
