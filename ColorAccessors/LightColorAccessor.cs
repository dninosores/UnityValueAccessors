﻿using System;
using UnityEngine;

namespace dninosores.UnityAccessors
{
	/// <summary>
	/// Get color from a light.
	/// </summary>
	[Serializable]
	public class LightColorAccessor : Accessor<Color>
	{
		[Tooltip("Light to get color from")]
		public Light light;

		public override Color GetValue()
		{
			return light.color;
		}

		public override void Reset(GameObject attachedObject)
		{
			light = attachedObject.GetComponent<Light>();
		}

		public override void SetValue(Color value)
		{
			light.color = value;
		}
	}
}