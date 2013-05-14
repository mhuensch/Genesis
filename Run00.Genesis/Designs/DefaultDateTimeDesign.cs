using System;

namespace Run00.Genesis.Designs
{
	public class DefaultDateTimeDesign : IntelligentDesign<DateTime>
	{
		protected override void InitializeDesign()
		{
			CreateUsing(() => DateTime.UtcNow.AddDays(_random.Next(365)));
		}

		#region private
		private static readonly Random _random = new Random();
		#endregion
	}
}
