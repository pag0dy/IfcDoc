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
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcProfileResource
{
	[Guid("ef3b6c2b-9c21-4445-83a4-2fa1d264bc10")]
	public partial class IfcProfileProperties : IfcExtendedProperties
	{
		[DataMember(Order=0)] 
		[XmlIgnore]
		[Required()]
		IfcProfileDef _ProfileDefinition;
	
	
		[Description("Profile definition which is qualified by these properties.")]
		public IfcProfileDef ProfileDefinition { get { return this._ProfileDefinition; } set { this._ProfileDefinition = value;} }
	
	
	}
	
}
