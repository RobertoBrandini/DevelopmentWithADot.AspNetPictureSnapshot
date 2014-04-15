﻿using System;
using System.Drawing;
using System.IO;

namespace DevelopmentWithADot.AspNetPictureSnapshot
{
	[Serializable]
	public sealed class PictureTakenEventArgs : EventArgs
	{
		public PictureTakenEventArgs(String base64Picture)
		{
			var index = base64Picture.IndexOf(',');
			var bytes = Convert.FromBase64String(base64Picture.Substring(index + 1));

			using (var stream = new MemoryStream(bytes))
			{
				this.Picture = Image.FromStream(stream);
			}
		}

		public Image Picture
		{
			get;
			private set;
		}
	}
}
