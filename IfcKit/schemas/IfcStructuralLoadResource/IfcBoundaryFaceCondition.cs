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
	public partial class IfcBoundaryFaceCondition : IfcBoundaryCondition
	{
		[DataMember(Order = 0)] 
		[Description("Translational stiffness value in x-direction of the coordinate system defined by the instance which uses this resource object.")]
		public IfcModulusOfSubgradeReactionSelect TranslationalStiffnessByAreaX { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Translational stiffness value in y-direction of the coordinate system defined by the instance which uses this resource object.")]
		public IfcModulusOfSubgradeReactionSelect TranslationalStiffnessByAreaY { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("Translational stiffness value in z-direction of the coordinate system defined by the instance which uses this resource object.")]
		public IfcModulusOfSubgradeReactionSelect TranslationalStiffnessByAreaZ { get; set; }
	
	
		public IfcBoundaryFaceCondition(IfcLabel? __Name, IfcModulusOfSubgradeReactionSelect __TranslationalStiffnessByAreaX, IfcModulusOfSubgradeReactionSelect __TranslationalStiffnessByAreaY, IfcModulusOfSubgradeReactionSelect __TranslationalStiffnessByAreaZ)
			: base(__Name)
		{
			this.TranslationalStiffnessByAreaX = __TranslationalStiffnessByAreaX;
			this.TranslationalStiffnessByAreaY = __TranslationalStiffnessByAreaY;
			this.TranslationalStiffnessByAreaZ = __TranslationalStiffnessByAreaZ;
		}
	
	
	}
	
}
