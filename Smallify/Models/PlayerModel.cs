using Smallify.Enums;
using Smallify.Interfaces;

namespace Smallify.Models
{
	public class PlayerModel : IPlayer
	{
		public PlayerModel(PlayerType playerType, int width, int height, int minWidth, int minHeight)
		{
			this.PlayerType = playerType;
			this.Width = width;
			this.Height = height;
			this.MinWidth = minWidth;
			this.MinHeight = minHeight;
		}

		public PlayerType PlayerType { get; }

		public double Width { get; set; }

		public double Height { get; set; }

		public double MinWidth { get; }

		public double MinHeight { get; }
	}
}
