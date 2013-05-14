using System;

namespace Run00.Genesis.Designs
{
	public class DefaultGuidDesign : IntelligentDesign<Guid>
	{
		protected override void InitializeDesign()
		{
			CreateUsing(() => Guid.NewGuid());
		}
	}
}
