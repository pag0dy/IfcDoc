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
	[Guid("1386f6f9-f668-4418-9168-55d106724177")]
	public partial class IfcBoundaryNodeCondition : IfcBoundaryCondition
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLinearStiffnessMeasure? _LinearStiffnessX;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLinearStiffnessMeasure? _LinearStiffnessY;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLinearStiffnessMeasure? _LinearStiffnessZ;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcRotationalStiffnessMeasure? _RotationalStiffnessX;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcRotationalStiffnessMeasure? _RotationalStiffnessY;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcRotationalStiffnessMeasure? _RotationalStiffnessZ;
	
	
		public IfcBoundaryNodeCondition()
		{
		}
	
		public IfcBoundaryNodeCondition(IfcLabel? __Name, IfcLinearStiffnessMeasure? __LinearStiffnessX, IfcLinearStiffnessMeasure? __LinearStiffnessY, IfcLinearStiffnessMeasure? __LinearStiffnessZ, IfcRotationalStiffnessMeasure? __RotationalStiffnessX, IfcRotationalStiffnessMeasure? __RotationalStiffnessY, IfcRotationalStiffnessMeasure? __RotationalStiffnessZ)
			: base(__Name)
		{
			this._LinearStiffnessX = __LinearStiffnessX;
			this._LinearStiffnessY = __LinearStiffnessY;
			this._LinearStiffnessZ = __LinearStiffnessZ;
			this._RotationalStiffnessX = __RotationalStiffnessX;
			this._RotationalStiffnessY = __RotationalStiffnessY;
			this._RotationalStiffnessZ = __RotationalStiffnessZ;
		}
	
		[Description("Linear stiffness value in x-direction of the coordinate system defined by the ins" +
	    "tance which uses this resource object. ")]
		public IfcLinearStiffnessMeasure? LinearStiffnessX { get { return this._LinearStiffnessX; } set { this._LinearStiffnessX = value;} }
	
		[Description("Linear stiffness value in y-direction of the coordinate system defined by the ins" +
	    "tance which uses this resource object.")]
		public IfcLinearStiffnessMeasure? LinearStiffnessY { get { return this._LinearStiffnessY; } set { this._LinearStiffnessY = value;} }
	
		[Description("Linear stiffness value in z-direction of the coordinate system defined by the ins" +
	    "tance which uses this resource object.")]
		public IfcLinearStiffnessMeasure? LinearStiffnessZ { get { return this._LinearStiffnessZ; } set { this._LinearStiffnessZ = value;} }
	
		[Description("Rotational stiffness value about the x-axis of the coordinate system defined by t" +
	    "he instance which uses this resource object.")]
		public IfcRotationalStiffnessMeasure? RotationalStiffnessX { get { return this._RotationalStiffnessX; } set { this._RotationalStiffnessX = value;} }
	
		[Description("Rotational stiffness value about the y-axis of the coordinate system defined by t" +
	    "he instance which uses this resource object.")]
		public IfcRotationalStiffnessMeasure? RotationalStiffnessY { get { return this._RotationalStiffnessY; } set { this._RotationalStiffnessY = value;} }
	
		[Description("Rotational stiffness value about the z-axis of the coordinate system defined by t" +
	    "he instance which uses this resource object.")]
		public IfcRotationalStiffnessMeasure? RotationalStiffnessZ { get { return this._RotationalStiffnessZ; } set { this._RotationalStiffnessZ = value;} }
	
	
	}
	
}
