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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;

namespace BuildingSmart.IFC.IfcMaterialResource
{
	[Guid("bbddf2c3-cd7d-4357-94ae-dc7c126b2265")]
	public partial class IfcMaterialProfileSetUsageTapering : IfcMaterialProfileSetUsage
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcMaterialProfileSet")]
		[Required()]
		IfcMaterialProfileSet _ForProfileEndSet;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcCardinalPointReference? _CardinalEndPoint;
	
	
		[Description("The second <em>IfcMaterialProfileSet</em> set to which the usage is applied.")]
		public IfcMaterialProfileSet ForProfileEndSet { get { return this._ForProfileEndSet; } set { this._ForProfileEndSet = value;} }
	
		[Description(@"Index reference to a significant point in the second section profile. Describes how this section is aligned relative to the axis of the member it is associated with. This parametric specification of profile alignment can be provided redundantly to the explicit alignment defined by ForProfileSet.MaterialProfiles[*].Profile.")]
		public IfcCardinalPointReference? CardinalEndPoint { get { return this._CardinalEndPoint; } set { this._CardinalEndPoint = value;} }
	
	
	}
	
}
