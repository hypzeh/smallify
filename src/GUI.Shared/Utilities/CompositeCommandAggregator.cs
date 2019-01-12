using GUI.Shared.Interfaces;
using Prism.Commands;
using System;
using System.Collections.Generic;

namespace GUI.Shared.Utilities
{
	public class CompositeCommandAggregator : ICompositeCommandAggregator
	{
		/// <summary>
		/// The composite commands
		/// </summary>
		private readonly Dictionary<Type, CompositeCommand> _compositeCommands = new Dictionary<Type, CompositeCommand>();

		/// <summary>
		/// Gets the instance
		/// </summary>
		/// <typeparam name="TCommandType">The command type</typeparam>
		/// <returns>a new command</returns>
		public TCommandType Get<TCommandType>() where TCommandType : CompositeCommand, new()
		{
			this._compositeCommands.TryGetValue(typeof(TCommandType), out var command);

			if (command == null)
			{
				command = new TCommandType();
				this._compositeCommands.Add(typeof(TCommandType), command);
			}

			return (TCommandType)command;
		}
	}
}