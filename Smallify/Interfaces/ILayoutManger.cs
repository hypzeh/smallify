using Smallify.Enums;
using Smallify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
