﻿﻿using System;
using Newtonsoft.Json;
namespace BigCat
{
    public class BigCatorNotModel
    {
		[JsonProperty(PropertyName = "Id")]
		public string ID { get; set; }

		[JsonProperty(PropertyName = "LionHeight")]
		public float LionHeight { get; set; }

		[JsonProperty(PropertyName = "TigerHeight")]
		public float TigerHeight { get; set; }

		
    }
}
