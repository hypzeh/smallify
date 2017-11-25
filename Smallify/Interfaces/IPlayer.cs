using Smallify.Enums;

namespace Smallify.Interfaces
{
	public interface IPlayer
	{
		PlayerType PlayerType { get; }

		double Width { get; set; }

		double Height { get; set; }

		double MinWidth { get; }

		double MinHeight { get; }
	}
}
