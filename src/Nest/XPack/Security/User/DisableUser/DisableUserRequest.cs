﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest_5_2_0
{
	public partial interface IDisableUserRequest { }

	public partial class DisableUserRequest { }

	[DescriptorFor("XpackSecurityDisableUser")]
	public partial class DisableUserDescriptor { }
}
