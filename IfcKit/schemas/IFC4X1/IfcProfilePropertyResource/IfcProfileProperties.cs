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
using BuildingSmart.IFC.IfcProfileResource;

namespace BuildingSmart.IFC.IfcProfilePropertyResource
{
	[Guid("33c6110b-f7fb-4b83-8ca1-4b101bf94669")]
	public abstract partial class IfcProfileProperties
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _ProfileName;
	
		[DataMember(Order=1)] 
		IfcProfileDef _ProfileDefinition;
	
	
		[Description("Standardized profile name as published in a profile table. All profile properties" +
	    " are applicable to this standardized profile name.")]
		public IfcLabel? ProfileName { get { return this._ProfileName; } set { this._ProfileName = value;} }
	
		[Description("Optional reference to an instance of IfcProfileDef, which contains a further geom" +
	    "etrical definition.")]
		public IfcProfileDef ProfileDefinition { get { return this._ProfileDefinition; } set { this._ProfileDefinition = value;} }
	
	
	}
	
}
