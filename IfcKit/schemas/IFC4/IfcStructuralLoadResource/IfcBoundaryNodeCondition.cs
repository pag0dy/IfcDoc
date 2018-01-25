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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcStructuralLoadResource
{
	[Guid("0454a0f4-fdfb-4856-bad8-c1a1202137d1")]
	public partial class IfcBoundaryNodeCondition : IfcBoundaryCondition
	{
		[DataMember(Order=0)] 
		IfcTranslationalStiffnessSelect _TranslationalStiffnessX;
	
		[DataMember(Order=1)] 
		IfcTranslationalStiffnessSelect _TranslationalStiffnessY;
	
		[DataMember(Order=2)] 
		IfcTranslationalStiffnessSelect _TranslationalStiffnessZ;
	
		[DataMember(Order=3)] 
		IfcRotationalStiffnessSelect _RotationalStiffnessX;
	
		[DataMember(Order=4)] 
		IfcRotationalStiffnessSelect _RotationalStiffnessY;
	
		[DataMember(Order=5)] 
		IfcRotationalStiffnessSelect _RotationalStiffnessZ;
	
	
		[Description("Translational stiffness value in x-direction of the coordinate system defined by " +
	    "the instance which uses this resource object.")]
		public IfcTranslationalStiffnessSelect TranslationalStiffnessX { get { return this._TranslationalStiffnessX; } set { this._TranslationalStiffnessX = value;} }
	
		[Description("Translational stiffness value in y-direction of the coordinate system defined by " +
	    "the instance which uses this resource object.")]
		public IfcTranslationalStiffnessSelect TranslationalStiffnessY { get { return this._TranslationalStiffnessY; } set { this._TranslationalStiffnessY = value;} }
	
		[Description("Translational stiffness value in z-direction of the coordinate system defined by " +
	    "the instance which uses this resource object.")]
		public IfcTranslationalStiffnessSelect TranslationalStiffnessZ { get { return this._TranslationalStiffnessZ; } set { this._TranslationalStiffnessZ = value;} }
	
		[Description("Rotational stiffness value about the x-axis of the coordinate system defined by t" +
	    "he instance which uses this resource object.")]
		public IfcRotationalStiffnessSelect RotationalStiffnessX { get { return this._RotationalStiffnessX; } set { this._RotationalStiffnessX = value;} }
	
		[Description("Rotational stiffness value about the y-axis of the coordinate system defined by t" +
	    "he instance which uses this resource object.")]
		public IfcRotationalStiffnessSelect RotationalStiffnessY { get { return this._RotationalStiffnessY; } set { this._RotationalStiffnessY = value;} }
	
		[Description("Rotational stiffness value about the z-axis of the coordinate system defined by t" +
	    "he instance which uses this resource object.")]
		public IfcRotationalStiffnessSelect RotationalStiffnessZ { get { return this._RotationalStiffnessZ; } set { this._RotationalStiffnessZ = value;} }
	
	
	}
	
}
