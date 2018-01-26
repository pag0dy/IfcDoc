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

namespace BuildingSmart.IFC.IfcProfileResource
{
	[Guid("e45af9c0-ad58-4513-b830-964881be1b09")]
	public partial class IfcDerivedProfileDef : IfcProfileDef
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcProfileDef _ParentProfile;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcCartesianTransformationOperator2D _Operator;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _Label;
	
	
		public IfcDerivedProfileDef()
		{
		}
	
		public IfcDerivedProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcProfileDef __ParentProfile, IfcCartesianTransformationOperator2D __Operator, IfcLabel? __Label)
			: base(__ProfileType, __ProfileName)
		{
			this._ParentProfile = __ParentProfile;
			this._Operator = __Operator;
			this._Label = __Label;
		}
	
		[Description("The parent profile provides the origin of the transformation.")]
		public IfcProfileDef ParentProfile { get { return this._ParentProfile; } set { this._ParentProfile = value;} }
	
		[Description("Transformation operator applied to the parent profile. ")]
		public IfcCartesianTransformationOperator2D Operator { get { return this._Operator; } set { this._Operator = value;} }
	
		[Description("The name by which the transformation may be referred to. The actual meaning of th" +
	    "e name has to be defined in the context of applications.")]
		public IfcLabel? Label { get { return this._Label; } set { this._Label = value;} }
	
	
	}
	
}
