namespace Smallify.Module.Core.Events.Configuration
{
	public class ConfigurationChangedEventArgs
	{
		public ConfigurationChangedEventArgs(
			string name,
			object value)
		{
			Name = name;
			Value = value;
		}

		public string Name { get; }

		public object Value { get; }
	}
}
