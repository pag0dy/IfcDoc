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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcProfileResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	public partial class IfcSectionedSpine : IfcGeometricRepresentationItem
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("A single composite curve, that defines the spine curve. Each of the composite curve segments correspond to the part between two cross-sections.")]
		[Required()]
		public IfcCompositeCurve SpineCurve { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("A list of at least two cross sections, each defined within the xy plane of the position coordinate system of the cross section. The position coordinate system is given by the corresponding list CrossSectionPositions.")]
		[Required()]
		[MinLength(2)]
		public IList<IfcProfileDef> CrossSections { get; protected set; }
	
		[DataMember(Order = 2)] 
		[Description("Position coordinate systems for the cross sections that form the sectioned spine. The profiles defining the cross sections are positioned within the xy plane of the corresponding position coordinate system.")]
		[Required()]
		[MinLength(2)]
		public IList<IfcAxis2Placement3D> CrossSectionPositions { get; protected set; }
	
	
		public IfcSectionedSpine(IfcCompositeCurve __SpineCurve, IfcProfileDef[] __CrossSections, IfcAxis2Placement3D[] __CrossSectionPositions)
		{
			this.SpineCurve = __SpineCurve;
			this.CrossSections = new List<IfcProfileDef>(__CrossSections);
			this.CrossSectionPositions = new List<IfcAxis2Placement3D>(__CrossSectionPositions);
		}
	
		public new IfcDimensionCount Dim { get { return new IfcDimensionCount(); } }
	
	
	}
	
}
