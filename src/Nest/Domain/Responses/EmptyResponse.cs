﻿using Newtonsoft.Json;

namespace Nest
{
	public interface IEmptyResponse : IResponse
	{
	}

	[JsonObject]
	public class EmptyResponse : BaseResponse, IEmptyResponse
	{
		public EmptyResponse()
		{
			this.IsValid = true;
		}
	}
}