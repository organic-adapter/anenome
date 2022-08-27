using Anenome.Business.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anenome.Business
{
	public interface IAnenomeConverter
	{
		public string Convert(Block block, PropertySort sort, string appendTo, int currentDepth = 0);
	}
}
