using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Browser;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;


namespace ZooMonkey
{
	[DataContract]
	public class ImageDefinition
	{
		public ImageDefinition()
		{
			Points = new double[4];
		}

		[DataMember]
		public string ImageUrl { get; set; }
		[DataMember]
		public double[] Points { get; set; }

		public double Left
		{
			get { return Points[0]; }
			set { Points[0] = value; }
		}

		public double Top
		{
			get { return Points[1]; }
			set { Points[1] = value; }
		}

		public double Width
		{
			get { return Points[2]; }
			set { Points[2] = value; }
		}

		public double Height
		{
			get { return Points[3]; }
			set { Points[3] = value; }
		}
	}

	[DataContract]
	public class ZooMonkeyAction
	{
		public ZooMonkeyAction()
		{
			Duration = 1;
		}

		[DataMember]
		public double Top { get; set; }
		[DataMember]
		public double Left { get; set; }
		[DataMember]
		public double Angle { get; set; }
		[DataMember]
		public double Zoom { get; set; }
		[DataMember (IsRequired=false)]
		public double Duration { get; set; }
	}

	[DataContract]
	public class ZooMonkeyData
	{
		public ZooMonkeyData()
		{
			Images = new List<ImageDefinition>();
			Actions = new List<ZooMonkeyAction>();
		}

		[DataMember]
		public string XamlUrl { get; set; }
		// FIXME: should be IList. Replace it once moonlight fix went into release
		[DataMember]
		public List<ImageDefinition> Images { get; set; }
		[DataMember]
		public List<ZooMonkeyAction> Actions { get; set; }
		[DataMember]
		public bool HighlightClosestImage { get; set; }
		[DataMember]
		public double NonHighlightedOpacity { get; set; }
	}
}
