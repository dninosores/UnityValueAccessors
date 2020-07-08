﻿using dninosores.UnityEditorAttributes;
using System;
using UnityEngine;

namespace dninosores.UnityAccessors
{
	[Serializable]
	public class Vector2Vector3Accessor : Accessor<Vector3>
	{

		public Axis3D xValueTo;
		public Axis3D yValueTo;
		public float fillConstant;

		public AnyFlatVector2Accessor vector2;



		public override Vector3 GetValue()
		{
			Vector3 outValue = new Vector3(fillConstant, fillConstant, fillConstant);
			Vector2 orig = vector2.Value;
			Vector3FloatUtil.SetValue(xValueTo, outValue, orig.x);
			Vector3FloatUtil.SetValue(yValueTo, outValue, orig.y);
			return outValue;
		}

		public override void Reset(GameObject attachedObject)
		{
			vector2 = new AnyFlatVector2Accessor();
			vector2.Reset(attachedObject);
			xValueTo = Axis3D.X;
			yValueTo = Axis3D.Y;
		}

		public override void SetValue(Vector3 value)
		{
			vector2.Value = new Vector2(Vector3FloatUtil.GetValue(xValueTo, value),
				Vector3FloatUtil.GetValue(yValueTo, value));
		}
	}
}