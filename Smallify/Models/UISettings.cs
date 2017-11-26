using Smallify.Enums;
using System;

namespace Smallify.Models
{
	[Serializable]
	public class UISettings
	{
		public double Width { get; set; }

		public double Height { get; set; }

		public double Top { get; set; }

		public double Left { get; set; }

		public PlayerType PlayerType { get; set; }

		public bool IsTopMost { get; set; }
	}
}
