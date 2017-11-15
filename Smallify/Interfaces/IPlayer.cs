using Smallify.Enums;

namespace Smallify.Interfaces
{
	public interface IPlayer
	{
		PlayerType PlayerType { get; }

		int Width { get; set; }

		int Height { get; set; }

		int MinWidth { get; }

		int MinHeight { get; }
	}
}
