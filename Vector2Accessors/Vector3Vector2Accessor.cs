﻿using System;
using UnityEngine;

namespace dninosores.UnityAccessors
{
	/// <summary>
	/// Accesses a Vector2 by converting it from a Vector3Accessor.
	/// </summary>
	[Serializable]
	public class Vector3Vector2Accessor : Accessor<Vector2>
	{
		[Tooltip("Which axis from the Vector3 should become the X axis for the Vector2?")]
		public Axis3D xSource;
		[Tooltip("Which axis from the Vector3 should become the Y axis for the Vector2?")]
		public Axis3D ySource;
		public AnyFlatVector3Accessor vector;


		public override Vector2 GetValue()
		{
			Vector3 v3 = vector.GetValue();
			return new Vector2(Vector3FloatUtil.GetValue(xSource, v3), Vector3FloatUtil.GetValue(ySource, v3));
		}

		public override void Reset(GameObject attachedObject)
		{
			xSource = Axis3D.X;
			ySource = Axis3D.Y;
			vector = new AnyFlatVector3Accessor();
			vector.Reset(attachedObject);
		}


		public override void SetValue(Vector2 value)
		{
			Vector3 target = vector.Value;
			Vector3FloatUtil.SetValue(xSource, target, value.x);
			Vector3FloatUtil.SetValue(ySource, target, value.y);
			vector.Value = target;
		}
	}

}