using System;
using System.IO;

namespace Run00.Genesis.Designs
{
	public class DefaultUri : IntelligentDesign<Uri>
	{
		protected override void InitializeDesign()
		{
			CreateUsing(() => new Uri(string.Format("http://www.{0}.com", Path.GetRandomFileName().Replace(".", ""))));
		}
	}
}
