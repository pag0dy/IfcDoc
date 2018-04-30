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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcProfileResource
{
	public partial class IfcDerivedProfileDef : IfcProfileDef
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("The parent profile provides the origin of the transformation.")]
		[Required()]
		public IfcProfileDef ParentProfile { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlElement]
		[Description("Transformation operator applied to the parent profile. ")]
		[Required()]
		public IfcCartesianTransformationOperator2D Operator { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The name by which the transformation may be referred to. The actual meaning of the name has to be defined in the context of applications.")]
		public IfcLabel? Label { get; set; }
	
	
		public IfcDerivedProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcProfileDef __ParentProfile, IfcCartesianTransformationOperator2D __Operator, IfcLabel? __Label)
			: base(__ProfileType, __ProfileName)
		{
			this.ParentProfile = __ParentProfile;
			this.Operator = __Operator;
			this.Label = __Label;
		}
	
	
	}
	
}
