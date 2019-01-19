using System.ComponentModel;

namespace Smallify.Module.Core
{
	public interface IConfiguration : INotifyPropertyChanged
	{
		string ClientID { get; }

		string AccessToken { get; set; }
	}
}
