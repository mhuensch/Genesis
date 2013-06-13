using System;

namespace Run00.Genesis.SimpleDesigns
{
	public class DefaultDateTimeDesign : IntelligentDesign<DateTime>
	{
		public DefaultDateTimeDesign()
		{
			CreateUsing(() => DateTime.UtcNow.AddDays(_random.Next(365)));
		}

		private static readonly Random _random = new Random();
	}
}
