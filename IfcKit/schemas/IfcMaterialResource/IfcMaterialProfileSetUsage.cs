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
using BuildingSmart.IFC.IfcProductExtension;

namespace BuildingSmart.IFC.IfcMaterialResource
{
	public partial class IfcMaterialProfileSetUsage : IfcMaterialUsageDefinition
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("The <em>IfcMaterialProfileSet</em> set to which the usage is applied.")]
		[Required()]
		public IfcMaterialProfileSet ForProfileSet { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Index reference to a significant point in the section profile. Describes how the section is aligned relative to the (longitudinal) axis of the member it is associated with. This parametric specification of profile alignment can be provided redundantly to the explicit alignment defined by ForProfileSet.MaterialProfiles[*].Profile.")]
		public IfcCardinalPointReference? CardinalPoint { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Extent of the extrusion of the elements body shape representation to which the <em>IfcMaterialProfileSetUsage</em> applies. It is used as the reference value for the upper <em>OffsetValues[2]</em> provided by the <em>IfcMaterialProfileSetWithOffsets</em> subtype for included material profiles.    <blockquote class=\"note\">NOTE&nbsp; The attribute <em>ReferenceExtent</em> shall be asserted if an <em>IfcMaterialProfileSetWithOffsets</em> is included in the <em>ForProfileSet.MaterialProfiles</em> list of material layers.</blockquote>  <blockquote class=\"note\">NOTE&nbsp; The <em>ReferenceExtent</em> for <em>IfcBeamStandardCase</em>, <em>IfcColumnStandardCase</em>, and <em>IfcMemberStandardCase</em> is the reference length starting at z=0 being the XY plane of the object coordinate system.</blockquote>")]
		public IfcPositiveLengthMeasure? ReferenceExtent { get; set; }
	
	
		public IfcMaterialProfileSetUsage(IfcMaterialProfileSet __ForProfileSet, IfcCardinalPointReference? __CardinalPoint, IfcPositiveLengthMeasure? __ReferenceExtent)
		{
			this.ForProfileSet = __ForProfileSet;
			this.CardinalPoint = __CardinalPoint;
			this.ReferenceExtent = __ReferenceExtent;
		}
	
	
	}
	
}
