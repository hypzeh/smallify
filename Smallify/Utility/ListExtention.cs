using System;
using System.Collections.Generic;
using System.Linq;

namespace Smallify.Utility
{
	public static class ListExtention
	{
		public static T PickRandom<T>(this List<T> enumerable)
		{
			var index = new Random().Next(0, enumerable.Count());
			return enumerable[index];
		}
	}
}
