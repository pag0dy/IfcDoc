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
	[Guid("4ba2918e-ce3b-4abc-85e7-561cd722c1c2")]
	public partial class IfcBoundaryFaceCondition : IfcBoundaryCondition
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcModulusOfSubgradeReactionMeasure? _LinearStiffnessByAreaX;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcModulusOfSubgradeReactionMeasure? _LinearStiffnessByAreaY;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcModulusOfSubgradeReactionMeasure? _LinearStiffnessByAreaZ;
	
	
		[Description("Linear stiffness value in x-direction of the coordinate system defined by the ins" +
	    "tance which uses this resource object.")]
		public IfcModulusOfSubgradeReactionMeasure? LinearStiffnessByAreaX { get { return this._LinearStiffnessByAreaX; } set { this._LinearStiffnessByAreaX = value;} }
	
		[Description("Linear stiffness value in y-direction of the coordinate system defined by the ins" +
	    "tance which uses this resource object.")]
		public IfcModulusOfSubgradeReactionMeasure? LinearStiffnessByAreaY { get { return this._LinearStiffnessByAreaY; } set { this._LinearStiffnessByAreaY = value;} }
	
		[Description("Linear stiffness value in z-direction of the coordinate system defined by the ins" +
	    "tance which uses this resource object.")]
		public IfcModulusOfSubgradeReactionMeasure? LinearStiffnessByAreaZ { get { return this._LinearStiffnessByAreaZ; } set { this._LinearStiffnessByAreaZ = value;} }
	
	
	}
	
}
