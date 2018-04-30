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
		[XmlAttribute]
		[Description("Linear stiffness value in x-direction of the coordinate system defined by the instance which uses this resource object.")]
		public IfcModulusOfLinearSubgradeReactionMeasure? LinearStiffnessByLengthX { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Linear stiffness value in y-direction of the coordinate system defined by the instance which uses this resource object.")]
		public IfcModulusOfLinearSubgradeReactionMeasure? LinearStiffnessByLengthY { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Linear stiffness value in z-direction of the coordinate system defined by the instance which uses this resource object.")]
		public IfcModulusOfLinearSubgradeReactionMeasure? LinearStiffnessByLengthZ { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Rotational stiffness value about the x-axis of the coordinate system defined by the instance which uses this resource object.")]
		public IfcModulusOfRotationalSubgradeReactionMeasure? RotationalStiffnessByLengthX { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Rotational stiffness value about the y-axis of the coordinate system defined by the instance which uses this resource object.")]
		public IfcModulusOfRotationalSubgradeReactionMeasure? RotationalStiffnessByLengthY { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("Rotational stiffness value about the z-axis of the coordinate system defined by the instance which uses this resource object.")]
		public IfcModulusOfRotationalSubgradeReactionMeasure? RotationalStiffnessByLengthZ { get; set; }
	
	
		public IfcBoundaryEdgeCondition(IfcLabel? __Name, IfcModulusOfLinearSubgradeReactionMeasure? __LinearStiffnessByLengthX, IfcModulusOfLinearSubgradeReactionMeasure? __LinearStiffnessByLengthY, IfcModulusOfLinearSubgradeReactionMeasure? __LinearStiffnessByLengthZ, IfcModulusOfRotationalSubgradeReactionMeasure? __RotationalStiffnessByLengthX, IfcModulusOfRotationalSubgradeReactionMeasure? __RotationalStiffnessByLengthY, IfcModulusOfRotationalSubgradeReactionMeasure? __RotationalStiffnessByLengthZ)
			: base(__Name)
		{
			this.LinearStiffnessByLengthX = __LinearStiffnessByLengthX;
			this.LinearStiffnessByLengthY = __LinearStiffnessByLengthY;
			this.LinearStiffnessByLengthZ = __LinearStiffnessByLengthZ;
			this.RotationalStiffnessByLengthX = __RotationalStiffnessByLengthX;
			this.RotationalStiffnessByLengthY = __RotationalStiffnessByLengthY;
			this.RotationalStiffnessByLengthZ = __RotationalStiffnessByLengthZ;
		}
	
	
	}
	
}
