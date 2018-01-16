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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfilePropertyResource;

namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	[Guid("cf91911e-b109-410a-bc39-45bb696de10e")]
	public partial class IfcReinforcingBar : IfcReinforcingElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _NominalDiameter;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcAreaMeasure _CrossSectionArea;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _BarLength;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcReinforcingBarRoleEnum _BarRole;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcReinforcingBarSurfaceEnum? _BarSurface;
	
	
		[Description("The nominal diameter defining the cross-section size of the reinforcing bar.")]
		public IfcPositiveLengthMeasure NominalDiameter { get { return this._NominalDiameter; } set { this._NominalDiameter = value;} }
	
		[Description("The effective cross-section area of the reinforcing bar.")]
		public IfcAreaMeasure CrossSectionArea { get { return this._CrossSectionArea; } set { this._CrossSectionArea = value;} }
	
		[Description("The total length of the reinforcing bar. The total length of bended bars are calc" +
	    "ulated according to local standards with corrections for the bends.\r\n")]
		public IfcPositiveLengthMeasure? BarLength { get { return this._BarLength; } set { this._BarLength = value;} }
	
		[Description("The role, purpose or usage of the bar, i.e. the kind of loads and stresses it is " +
	    "intended to carry.\r\n")]
		public IfcReinforcingBarRoleEnum BarRole { get { return this._BarRole; } set { this._BarRole = value;} }
	
		[Description("Indicator for whether the bar surface is plain or textured.\r\n")]
		public IfcReinforcingBarSurfaceEnum? BarSurface { get { return this._BarSurface; } set { this._BarSurface = value;} }
	
	
	}
	
}
