using System;
using System.Collections.Generic;
using System.Linq;

namespace Smallify.Module.Core.Constants
{
	public static class WelcomeMessage
	{
		private static IEnumerable<string> _messages =>
			new List<string>
			{
				"🎈",
				"🐧",
				"🎼",
				"🎧",
				"🎵",
				"🎶",
				"❤"
			};

		public static string GetRandom() =>
			_messages.ElementAtOrDefault(new Random().Next(_messages.Count()));
	}
}
