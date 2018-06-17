using Prism.Commands;

namespace GUI.Shared.Interfaces
{
	public interface ICompositeCommandAggregator
	{
		/// <summary>
		/// Get this instance
		/// </summary>
		/// <typeparam name="TCommandType">The command type</typeparam>
		/// <returns>An existing or new composite command</returns>
		TCommandType Get<TCommandType>() where TCommandType : CompositeCommand, new();
	}
}