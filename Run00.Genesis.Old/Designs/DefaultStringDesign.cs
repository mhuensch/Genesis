using System.IO;

namespace Run00.Genesis.Designs
{
	public class DefaultStringDesign : IntelligentDesign<string>
	{
		protected override void InitializeDesign()
		{
			CreateUsing(() => Path.GetRandomFileName().Replace(".", ""));
		}
	}
}
