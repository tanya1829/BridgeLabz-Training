using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelTracker
{
    internal class ParcelStage
    {
		private string stageName;

		public ParcelStage(string stageName)
		{
			this.stageName = stageName;
		}

		public string GetStage()
		{
			return stageName;
		}
	}
}
