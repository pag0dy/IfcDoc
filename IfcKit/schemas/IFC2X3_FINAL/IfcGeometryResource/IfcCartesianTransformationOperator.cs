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

using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("74f28ee8-1bff-4f28-bfde-eaa2ccce9e9d")]
	public abstract partial class IfcCartesianTransformationOperator : IfcGeometricRepresentationItem
	{
		[DataMember(Order=0)] 
		IfcDirection _Axis1;
	
		[DataMember(Order=1)] 
		IfcDirection _Axis2;
	
		[DataMember(Order=2)] 
		[Required()]
		IfcCartesianPoint _LocalOrigin;
	
		[DataMember(Order=3)] 
		Double? _Scale;
	
	
		public IfcCartesianTransformationOperator()
		{
		}
	
		public IfcCartesianTransformationOperator(IfcDirection __Axis1, IfcDirection __Axis2, IfcCartesianPoint __LocalOrigin, Double? __Scale)
		{
			this._Axis1 = __Axis1;
			this._Axis2 = __Axis2;
			this._LocalOrigin = __LocalOrigin;
			this._Scale = __Scale;
		}
	
		[Description("The direction used to determine U[1], the derived X axis direction.")]
		public IfcDirection Axis1 { get { return this._Axis1; } set { this._Axis1 = value;} }
	
		[Description("The direction used to determine U[2], the derived Y axis direction.")]
		public IfcDirection Axis2 { get { return this._Axis2; } set { this._Axis2 = value;} }
	
		[Description("The required translation, specified as a cartesian point. The actual translation " +
	    "included in the transformation is from the geometric origin to the local origin." +
	    "")]
		public IfcCartesianPoint LocalOrigin { get { return this._LocalOrigin; } set { this._LocalOrigin = value;} }
	
		[Description("The scaling value specified for the transformation.")]
		public Double? Scale { get { return this._Scale; } set { this._Scale = value;} }

        public new Double Scl { get { return 0.0; } }
	
		public new IfcDimensionCount Dim { get { return new IfcDimensionCount(); } }
	
	
	}
	
}
