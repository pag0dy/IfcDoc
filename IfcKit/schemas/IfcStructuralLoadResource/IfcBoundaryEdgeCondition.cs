// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
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
	public partial class IfcBoundaryEdgeCondition : IfcBoundaryCondition
	{
		[DataMember(Order = 0)] 
		[Description("Translational stiffness value in x-direction of the coordinate system defined by the instance which uses this resource object.")]
		public IfcModulusOfTranslationalSubgradeReactionSelect TranslationalStiffnessByLengthX { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Translational stiffness value in y-direction of the coordinate system defined by the instance which uses this resource object.")]
		public IfcModulusOfTranslationalSubgradeReactionSelect TranslationalStiffnessByLengthY { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("Translational stiffness value in z-direction of the coordinate system defined by the instance which uses this resource object.")]
		public IfcModulusOfTranslationalSubgradeReactionSelect TranslationalStiffnessByLengthZ { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("Rotational stiffness value about the x-axis of the coordinate system defined by the instance which uses this resource object.")]
		public IfcModulusOfRotationalSubgradeReactionSelect RotationalStiffnessByLengthX { get; set; }
	
		[DataMember(Order = 4)] 
		[Description("Rotational stiffness value about the y-axis of the coordinate system defined by the instance which uses this resource object.")]
		public IfcModulusOfRotationalSubgradeReactionSelect RotationalStiffnessByLengthY { get; set; }
	
		[DataMember(Order = 5)] 
		[Description("Rotational stiffness value about the z-axis of the coordinate system defined by the instance which uses this resource object.")]
		public IfcModulusOfRotationalSubgradeReactionSelect RotationalStiffnessByLengthZ { get; set; }
	
	
		public IfcBoundaryEdgeCondition(IfcLabel? __Name, IfcModulusOfTranslationalSubgradeReactionSelect __TranslationalStiffnessByLengthX, IfcModulusOfTranslationalSubgradeReactionSelect __TranslationalStiffnessByLengthY, IfcModulusOfTranslationalSubgradeReactionSelect __TranslationalStiffnessByLengthZ, IfcModulusOfRotationalSubgradeReactionSelect __RotationalStiffnessByLengthX, IfcModulusOfRotationalSubgradeReactionSelect __RotationalStiffnessByLengthY, IfcModulusOfRotationalSubgradeReactionSelect __RotationalStiffnessByLengthZ)
			: base(__Name)
		{
			this.TranslationalStiffnessByLengthX = __TranslationalStiffnessByLengthX;
			this.TranslationalStiffnessByLengthY = __TranslationalStiffnessByLengthY;
			this.TranslationalStiffnessByLengthZ = __TranslationalStiffnessByLengthZ;
			this.RotationalStiffnessByLengthX = __RotationalStiffnessByLengthX;
			this.RotationalStiffnessByLengthY = __RotationalStiffnessByLengthY;
			this.RotationalStiffnessByLengthZ = __RotationalStiffnessByLengthZ;
		}
	
	
	}
	
}
