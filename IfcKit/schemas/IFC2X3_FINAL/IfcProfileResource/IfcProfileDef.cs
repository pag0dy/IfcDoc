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

namespace BuildingSmart.IFC.IfcProfileResource
{
	[Guid("d0cfbce9-7565-4943-8f2a-2d7d736f6ae1")]
	public abstract partial class IfcProfileDef
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcProfileTypeEnum _ProfileType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _ProfileName;
	
	
		[Description(@"Defines the type of geometry into which this profile definition shall be resolved, either a curve or a surface area. In case of curve the profile should be referenced by a swept surface, in case of area the profile should be referenced by a swept area solid.")]
		public IfcProfileTypeEnum ProfileType { get { return this._ProfileType; } set { this._ProfileType = value;} }
	
		[Description("Name of the profile type according to some standard profile table. ")]
		public IfcLabel? ProfileName { get { return this._ProfileName; } set { this._ProfileName = value;} }
	
	
	}
	
}
