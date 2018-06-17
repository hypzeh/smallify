using System;

namespace GUI.Shared.Utilities
{
	public class EventArgs<T> : EventArgs
	{
		public EventArgs(T value)
		{
			this.Value = value;
		}

		public T Value { get; set; }

		public override string ToString()
		{
			return base.ToString();
		}
	}
}