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
	[Guid("85e8748b-e47c-4c11-8221-841a47ee4045")]
	public partial class IfcBoundaryEdgeCondition : IfcBoundaryCondition
	{
		[DataMember(Order=0)] 
		IfcModulusOfTranslationalSubgradeReactionSelect _TranslationalStiffnessByLengthX;
	
		[DataMember(Order=1)] 
		IfcModulusOfTranslationalSubgradeReactionSelect _TranslationalStiffnessByLengthY;
	
		[DataMember(Order=2)] 
		IfcModulusOfTranslationalSubgradeReactionSelect _TranslationalStiffnessByLengthZ;
	
		[DataMember(Order=3)] 
		IfcModulusOfRotationalSubgradeReactionSelect _RotationalStiffnessByLengthX;
	
		[DataMember(Order=4)] 
		IfcModulusOfRotationalSubgradeReactionSelect _RotationalStiffnessByLengthY;
	
		[DataMember(Order=5)] 
		IfcModulusOfRotationalSubgradeReactionSelect _RotationalStiffnessByLengthZ;
	
	
		[Description("Translational stiffness value in x-direction of the coordinate system defined by " +
	    "the instance which uses this resource object.")]
		public IfcModulusOfTranslationalSubgradeReactionSelect TranslationalStiffnessByLengthX { get { return this._TranslationalStiffnessByLengthX; } set { this._TranslationalStiffnessByLengthX = value;} }
	
		[Description("Translational stiffness value in y-direction of the coordinate system defined by " +
	    "the instance which uses this resource object.")]
		public IfcModulusOfTranslationalSubgradeReactionSelect TranslationalStiffnessByLengthY { get { return this._TranslationalStiffnessByLengthY; } set { this._TranslationalStiffnessByLengthY = value;} }
	
		[Description("Translational stiffness value in z-direction of the coordinate system defined by " +
	    "the instance which uses this resource object.")]
		public IfcModulusOfTranslationalSubgradeReactionSelect TranslationalStiffnessByLengthZ { get { return this._TranslationalStiffnessByLengthZ; } set { this._TranslationalStiffnessByLengthZ = value;} }
	
		[Description("Rotational stiffness value about the x-axis of the coordinate system defined by t" +
	    "he instance which uses this resource object.")]
		public IfcModulusOfRotationalSubgradeReactionSelect RotationalStiffnessByLengthX { get { return this._RotationalStiffnessByLengthX; } set { this._RotationalStiffnessByLengthX = value;} }
	
		[Description("Rotational stiffness value about the y-axis of the coordinate system defined by t" +
	    "he instance which uses this resource object.")]
		public IfcModulusOfRotationalSubgradeReactionSelect RotationalStiffnessByLengthY { get { return this._RotationalStiffnessByLengthY; } set { this._RotationalStiffnessByLengthY = value;} }
	
		[Description("Rotational stiffness value about the z-axis of the coordinate system defined by t" +
	    "he instance which uses this resource object.")]
		public IfcModulusOfRotationalSubgradeReactionSelect RotationalStiffnessByLengthZ { get { return this._RotationalStiffnessByLengthZ; } set { this._RotationalStiffnessByLengthZ = value;} }
	
	
	}
	
}
