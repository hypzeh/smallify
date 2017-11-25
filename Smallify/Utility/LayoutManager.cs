using Smallify.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smallify.Models;
using System.IO;
using Smallify.Enums;

namespace Smallify.Utility
{
	public class LayoutManager : ILayoutManger
	{
		public UISettings LoadLayout()
		{
			return new UISettings
			{
				Width = Properties.Settings.Default.Width,
				Height = Properties.Settings.Default.Height,
				Top = Properties.Settings.Default.Top,
				Left = Properties.Settings.Default.Left,
				PlayerType = (PlayerType)Properties.Settings.Default.PlayerType,
				IsTopMost = Properties.Settings.Default.IsTopMost
			};
		}

		public void SaveLayout(double width, double height, double top, double left)
		{
			Properties.Settings.Default.Width = width;
			Properties.Settings.Default.Height = height;
			Properties.Settings.Default.Top = top;
			Properties.Settings.Default.Left = left;
			Properties.Settings.Default.Save();
		}

		public void SavePlayer(PlayerType playerType)
		{
			Properties.Settings.Default.PlayerType = (int)playerType;
			Properties.Settings.Default.Save();
		}

		public void SavePreferences(bool isTopMost)
		{
			Properties.Settings.Default.IsTopMost = isTopMost;
			Properties.Settings.Default.Save();
		}
	}
}
