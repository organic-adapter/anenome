using Anenome.Business.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anenome.Business
{
	public interface IAnenomeFormatter
	{
		public string Format(Block block, PropertySort sort, string appendTo, int currentDepth = 0);
	}
}
