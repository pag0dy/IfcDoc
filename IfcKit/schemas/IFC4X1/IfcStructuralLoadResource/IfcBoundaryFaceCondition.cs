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
	[Guid("fa24f0f1-91ba-46b3-a264-4ec1679a4bce")]
	public partial class IfcBoundaryFaceCondition : IfcBoundaryCondition
	{
		[DataMember(Order=0)] 
		IfcModulusOfSubgradeReactionSelect _TranslationalStiffnessByAreaX;
	
		[DataMember(Order=1)] 
		IfcModulusOfSubgradeReactionSelect _TranslationalStiffnessByAreaY;
	
		[DataMember(Order=2)] 
		IfcModulusOfSubgradeReactionSelect _TranslationalStiffnessByAreaZ;
	
	
		[Description("Translational stiffness value in x-direction of the coordinate system defined by " +
	    "the instance which uses this resource object.")]
		public IfcModulusOfSubgradeReactionSelect TranslationalStiffnessByAreaX { get { return this._TranslationalStiffnessByAreaX; } set { this._TranslationalStiffnessByAreaX = value;} }
	
		[Description("Translational stiffness value in y-direction of the coordinate system defined by " +
	    "the instance which uses this resource object.")]
		public IfcModulusOfSubgradeReactionSelect TranslationalStiffnessByAreaY { get { return this._TranslationalStiffnessByAreaY; } set { this._TranslationalStiffnessByAreaY = value;} }
	
		[Description("Translational stiffness value in z-direction of the coordinate system defined by " +
	    "the instance which uses this resource object.")]
		public IfcModulusOfSubgradeReactionSelect TranslationalStiffnessByAreaZ { get { return this._TranslationalStiffnessByAreaZ; } set { this._TranslationalStiffnessByAreaZ = value;} }
	
	
	}
	
}
