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
	[Guid("f702e9bf-6873-48a7-b45f-d2ed1a04333d")]
	public partial class IfcBoundaryEdgeCondition : IfcBoundaryCondition
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcModulusOfLinearSubgradeReactionMeasure? _LinearStiffnessByLengthX;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcModulusOfLinearSubgradeReactionMeasure? _LinearStiffnessByLengthY;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcModulusOfLinearSubgradeReactionMeasure? _LinearStiffnessByLengthZ;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcModulusOfRotationalSubgradeReactionMeasure? _RotationalStiffnessByLengthX;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcModulusOfRotationalSubgradeReactionMeasure? _RotationalStiffnessByLengthY;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcModulusOfRotationalSubgradeReactionMeasure? _RotationalStiffnessByLengthZ;
	
	
		public IfcBoundaryEdgeCondition()
		{
		}
	
		public IfcBoundaryEdgeCondition(IfcLabel? __Name, IfcModulusOfLinearSubgradeReactionMeasure? __LinearStiffnessByLengthX, IfcModulusOfLinearSubgradeReactionMeasure? __LinearStiffnessByLengthY, IfcModulusOfLinearSubgradeReactionMeasure? __LinearStiffnessByLengthZ, IfcModulusOfRotationalSubgradeReactionMeasure? __RotationalStiffnessByLengthX, IfcModulusOfRotationalSubgradeReactionMeasure? __RotationalStiffnessByLengthY, IfcModulusOfRotationalSubgradeReactionMeasure? __RotationalStiffnessByLengthZ)
			: base(__Name)
		{
			this._LinearStiffnessByLengthX = __LinearStiffnessByLengthX;
			this._LinearStiffnessByLengthY = __LinearStiffnessByLengthY;
			this._LinearStiffnessByLengthZ = __LinearStiffnessByLengthZ;
			this._RotationalStiffnessByLengthX = __RotationalStiffnessByLengthX;
			this._RotationalStiffnessByLengthY = __RotationalStiffnessByLengthY;
			this._RotationalStiffnessByLengthZ = __RotationalStiffnessByLengthZ;
		}
	
		[Description("Linear stiffness value in x-direction of the coordinate system defined by the ins" +
	    "tance which uses this resource object.")]
		public IfcModulusOfLinearSubgradeReactionMeasure? LinearStiffnessByLengthX { get { return this._LinearStiffnessByLengthX; } set { this._LinearStiffnessByLengthX = value;} }
	
		[Description("Linear stiffness value in y-direction of the coordinate system defined by the ins" +
	    "tance which uses this resource object.")]
		public IfcModulusOfLinearSubgradeReactionMeasure? LinearStiffnessByLengthY { get { return this._LinearStiffnessByLengthY; } set { this._LinearStiffnessByLengthY = value;} }
	
		[Description("Linear stiffness value in z-direction of the coordinate system defined by the ins" +
	    "tance which uses this resource object.")]
		public IfcModulusOfLinearSubgradeReactionMeasure? LinearStiffnessByLengthZ { get { return this._LinearStiffnessByLengthZ; } set { this._LinearStiffnessByLengthZ = value;} }
	
		[Description("Rotational stiffness value about the x-axis of the coordinate system defined by t" +
	    "he instance which uses this resource object.")]
		public IfcModulusOfRotationalSubgradeReactionMeasure? RotationalStiffnessByLengthX { get { return this._RotationalStiffnessByLengthX; } set { this._RotationalStiffnessByLengthX = value;} }
	
		[Description("Rotational stiffness value about the y-axis of the coordinate system defined by t" +
	    "he instance which uses this resource object.")]
		public IfcModulusOfRotationalSubgradeReactionMeasure? RotationalStiffnessByLengthY { get { return this._RotationalStiffnessByLengthY; } set { this._RotationalStiffnessByLengthY = value;} }
	
		[Description("Rotational stiffness value about the z-axis of the coordinate system defined by t" +
	    "he instance which uses this resource object.")]
		public IfcModulusOfRotationalSubgradeReactionMeasure? RotationalStiffnessByLengthZ { get { return this._RotationalStiffnessByLengthZ; } set { this._RotationalStiffnessByLengthZ = value;} }
	
	
	}
	
}
