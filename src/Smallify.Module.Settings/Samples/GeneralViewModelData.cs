using Smallify.Module.Settings.ViewModels.Sections;
using System;

namespace Smallify.Module.Settings.Samples
{
	public class GeneralViewModelData : IGeneralViewModel
	{
		public bool AlwaysOnTopEnabled
		{
			get => true;
			set => throw new NotImplementedException();
		}
	}
}
