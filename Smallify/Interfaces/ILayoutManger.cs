using Smallify.Enums;
using Smallify.Models;
namespace Smallify.Interfaces
{
	public interface ILayoutManger
	{
		UISettings LoadLayout();

		void SaveLayout(double width, double height, double top, double left);

		void SavePlayer(PlayerType playerType);

		void SavePreferences(bool isTopMost);
	}
}
