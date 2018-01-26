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
using BuildingSmart.IFC.IfcProductExtension;

namespace BuildingSmart.IFC.IfcMaterialResource
{
	[Guid("1ca68971-59c5-4363-bcf5-4a3bf1006eae")]
	public partial class IfcMaterialProfileSetUsage : IfcMaterialUsageDefinition
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcMaterialProfileSet _ForProfileSet;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcCardinalPointReference? _CardinalPoint;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _ReferenceExtent;
	
	
		public IfcMaterialProfileSetUsage()
		{
		}
	
		public IfcMaterialProfileSetUsage(IfcMaterialProfileSet __ForProfileSet, IfcCardinalPointReference? __CardinalPoint, IfcPositiveLengthMeasure? __ReferenceExtent)
		{
			this._ForProfileSet = __ForProfileSet;
			this._CardinalPoint = __CardinalPoint;
			this._ReferenceExtent = __ReferenceExtent;
		}
	
		[Description("The <em>IfcMaterialProfileSet</em> set to which the usage is applied.")]
		public IfcMaterialProfileSet ForProfileSet { get { return this._ForProfileSet; } set { this._ForProfileSet = value;} }
	
		[Description(@"Index reference to a significant point in the section profile. Describes how the section is aligned relative to the (longitudinal) axis of the member it is associated with. This parametric specification of profile alignment can be provided redundantly to the explicit alignment defined by ForProfileSet.MaterialProfiles[*].Profile.")]
		public IfcCardinalPointReference? CardinalPoint { get { return this._CardinalPoint; } set { this._CardinalPoint = value;} }
	
		[Description(@"Extent of the extrusion of the elements body shape representation to which the <em>IfcMaterialProfileSetUsage</em> applies. It is used as the reference value for the upper <em>OffsetValues[2]</em> provided by the <em>IfcMaterialProfileSetWithOffsets</em> subtype for included material profiles.
	
	<blockquote class=""note"">NOTE&nbsp; The attribute <em>ReferenceExtent</em> shall be asserted if an <em>IfcMaterialProfileSetWithOffsets</em> is included in the <em>ForProfileSet.MaterialProfiles</em> list of material layers.</blockquote>
	<blockquote class=""note"">NOTE&nbsp; The <em>ReferenceExtent</em> for <em>IfcBeamStandardCase</em>, <em>IfcColumnStandardCase</em>, and <em>IfcMemberStandardCase</em> is the reference length starting at z=0 being the XY plane of the object coordinate system.</blockquote>")]
		public IfcPositiveLengthMeasure? ReferenceExtent { get { return this._ReferenceExtent; } set { this._ReferenceExtent = value;} }
	
	
	}
	
}
