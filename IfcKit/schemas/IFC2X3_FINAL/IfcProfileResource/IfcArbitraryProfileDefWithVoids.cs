// This file was automatically generated from IFCDOC at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcProfileResource
{
	[Guid("62f8cb22-db5c-4493-b485-ee0b7375d721")]
	public partial class IfcArbitraryProfileDefWithVoids : IfcArbitraryClosedProfileDef
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcCurve> _InnerCurves = new HashSet<IfcCurve>();
	
	
		public IfcArbitraryProfileDefWithVoids()
		{
		}
	
		public IfcArbitraryProfileDefWithVoids(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcCurve __OuterCurve, IfcCurve[] __InnerCurves)
			: base(__ProfileType, __ProfileName, __OuterCurve)
		{
			this._InnerCurves = new HashSet<IfcCurve>(__InnerCurves);
		}
	
		[Description("Set of bounded curves, defining the inner boundaries of the arbitrary profile.")]
		public ISet<IfcCurve> InnerCurves { get { return this._InnerCurves; } }
	
	
	}
	
}
