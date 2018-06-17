using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace GUI.Shared.Converters
{
	public sealed class BooleanToVisibilityConverter : BoolToVisibilityConverter<Visibility>
	{
		public BooleanToVisibilityConverter() :
			base(Visibility.Visible, Visibility.Collapsed)
		{
		}
	}

	public class BoolToVisibilityConverter<T> : IValueConverter
	{
		public BoolToVisibilityConverter(T trueValue, T falseValue)
		{
			this.True = trueValue;
			this.False = falseValue;
		}

		public T False { get; set; }

		public T True { get; set; }

		public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value is bool && ((bool)value) ? this.True : this.False;
		}

		public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value is T && EqualityComparer<T>.Default.Equals((T)value, this.True);
		}
	}
}