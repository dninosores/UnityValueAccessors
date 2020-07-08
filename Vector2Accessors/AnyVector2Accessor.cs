﻿using dninosores.UnityEditorAttributes;
using System;
using UnityEngine;

namespace dninosores.UnityAccessors
{
	[Serializable]
	public class AnyVector2Accessor : Accessor<Vector2>
	{
		public enum AccessType
		{
			RectTransform,
			Vector3,
			Float,
			Custom,
			Reflected,
			Constant
		}

		public AccessType accessType;

		[ConditionalHide("accessType", AccessType.RectTransform, "Accessor")]
		public RectTransformVector2Accessor rect;

		[ConditionalHide("accessType", AccessType.Custom, "Accessor")]
		public CustomVector2Accessor cust;

		[ConditionalHide("accessType", AccessType.Reflected, "Accessor")]
		public ReflectedVector2Accessor reflect;

		[ConditionalHide("accessType", AccessType.Vector3, "Accessor")]
		public Vector3Vector2Accessor vector3;

		[ConditionalHide("accessType", AccessType.Float, "Accessor")]
		public FloatVector2Accessor Float;

		[ConditionalHide("accessType", AccessType.Constant, "Accessor")]
		public ConstantVector2Accessor constant;

		public override Vector2 GetValue()
		{
			switch (accessType)
			{
				case AccessType.RectTransform:
					return rect.GetValue();
				case AccessType.Custom:
					return cust.GetValue();
				case AccessType.Reflected:
					return reflect.GetValue();
				case AccessType.Constant:
					return constant.Value;
				case AccessType.Vector3:
					return vector3.Value;
				case AccessType.Float:
					return Float.Value;
				default:
					throw new NotImplementedException("Case not found for " + accessType);
			}
		}


		public override void Reset(GameObject attachedObject)
		{
			rect = new RectTransformVector2Accessor();
			rect.Reset(attachedObject);
			cust = attachedObject.GetComponent<CustomVector2Accessor>();
			reflect = new ReflectedVector2Accessor();
			reflect.Reset(attachedObject);
			vector3 = null;
			constant = new ConstantVector2Accessor();
			constant.Reset(attachedObject);
			vector3 = new Vector3Vector2Accessor();
			vector3.Reset(attachedObject);
			Float = new FloatVector2Accessor();
			Float.Reset(attachedObject);
		}


		public override void SetValue(Vector2 value)
		{
			switch (accessType)
			{
				case AccessType.RectTransform:
					rect.SetValue(value);
					break;
				case AccessType.Custom:
					cust.SetValue(value);
					break;
				case AccessType.Reflected:
					reflect.SetValue(value);
					break;
				case AccessType.Constant:
					constant.Value = value;
					break;
				case AccessType.Vector3:
					vector3.Value = value;
					break;
				case AccessType.Float:
					Float.Value = value;
					break;
				default:
					throw new NotImplementedException("Case not found for " + accessType);
			}
		}
	}
}