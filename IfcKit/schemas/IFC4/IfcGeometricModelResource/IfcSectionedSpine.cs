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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("d92abdea-e3e3-4799-9cb5-39b1c40f03aa")]
	public partial class IfcSectionedSpine : IfcGeometricRepresentationItem
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcCompositeCurve")]
		[Required()]
		IfcCompositeCurve _SpineCurve;
	
		[DataMember(Order=1)] 
		[Required()]
		IList<IfcProfileDef> _CrossSections = new List<IfcProfileDef>();
	
		[DataMember(Order=2)] 
		[Required()]
		IList<IfcAxis2Placement3D> _CrossSectionPositions = new List<IfcAxis2Placement3D>();
	
	
		[Description("A single composite curve, that defines the spine curve. Each of the composite cur" +
	    "ve segments correspond to the part between two cross-sections.")]
		public IfcCompositeCurve SpineCurve { get { return this._SpineCurve; } set { this._SpineCurve = value;} }
	
		[Description("A list of at least two cross sections, each defined within the xy plane of the po" +
	    "sition coordinate system of the cross section. The position coordinate system is" +
	    " given by the corresponding list CrossSectionPositions.")]
		public IList<IfcProfileDef> CrossSections { get { return this._CrossSections; } }
	
		[Description("Position coordinate systems for the cross sections that form the sectioned spine." +
	    " The profiles defining the cross sections are positioned within the xy plane of " +
	    "the corresponding position coordinate system.")]
		public IList<IfcAxis2Placement3D> CrossSectionPositions { get { return this._CrossSectionPositions; } }
	
	
	}
	
}
