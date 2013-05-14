using System;

namespace Run00.Genesis.Designs
{
	public class DefaultIntDesign : IntelligentDesign<int>
	{
		protected override void InitializeDesign()
		{
			CreateUsing(() => _random.Next());
		}

		#region private
		private static readonly Random _random = new Random();
		#endregion
	}
}
