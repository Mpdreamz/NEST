﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest_5_2_0
{
	public interface IPutMappingResponse : IIndicesResponse { }

	public class PutMappingResponse : IndicesResponseBase, IPutMappingResponse { }
}
