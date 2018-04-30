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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcProfileResource
{
	public partial class IfcProfileProperties : IfcExtendedProperties
	{
		[DataMember(Order = 0)] 
		[XmlIgnore]
		[Description("Profile definition which is qualified by these properties.")]
		[Required()]
		public IfcProfileDef ProfileDefinition { get; set; }
	
	
		public IfcProfileProperties(IfcIdentifier? __Name, IfcText? __Description, IfcProperty[] __Properties, IfcProfileDef __ProfileDefinition)
			: base(__Name, __Description, __Properties)
		{
			this.ProfileDefinition = __ProfileDefinition;
		}
	
	
	}
	
}
