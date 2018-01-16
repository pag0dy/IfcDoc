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
	[Guid("1603d564-704f-40ac-8e69-4434b6e56839")]
	public partial class IfcStructuralLoadLinearForce : IfcStructuralLoadStatic
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLinearForceMeasure? _LinearForceX;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLinearForceMeasure? _LinearForceY;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLinearForceMeasure? _LinearForceZ;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcLinearMomentMeasure? _LinearMomentX;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcLinearMomentMeasure? _LinearMomentY;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcLinearMomentMeasure? _LinearMomentZ;
	
	
		[Description("Linear force value in x-direction. ")]
		public IfcLinearForceMeasure? LinearForceX { get { return this._LinearForceX; } set { this._LinearForceX = value;} }
	
		[Description("Linear force value in y-direction.")]
		public IfcLinearForceMeasure? LinearForceY { get { return this._LinearForceY; } set { this._LinearForceY = value;} }
	
		[Description("Linear force value in z-direction. ")]
		public IfcLinearForceMeasure? LinearForceZ { get { return this._LinearForceZ; } set { this._LinearForceZ = value;} }
	
		[Description("Linear moment about the x-axis.")]
		public IfcLinearMomentMeasure? LinearMomentX { get { return this._LinearMomentX; } set { this._LinearMomentX = value;} }
	
		[Description("Linear moment about the y-axis.")]
		public IfcLinearMomentMeasure? LinearMomentY { get { return this._LinearMomentY; } set { this._LinearMomentY = value;} }
	
		[Description("Linear moment about the z-axis.")]
		public IfcLinearMomentMeasure? LinearMomentZ { get { return this._LinearMomentZ; } set { this._LinearMomentZ = value;} }
	
	
	}
	
}
