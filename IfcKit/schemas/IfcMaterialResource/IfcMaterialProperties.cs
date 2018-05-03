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

namespace BuildingSmart.IFC.IfcMaterialResource
{
	public partial class IfcMaterialProperties : IfcExtendedProperties
	{
		[DataMember(Order = 0)] 
		[XmlIgnore]
		[Description("Reference to the material definition to which the set of properties is assigned.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE  The datatype has been changed to supertype <em>IfcMaterialDefinition</em>.</blockquote>")]
		[Required()]
		public IfcMaterialDefinition Material { get; set; }
	
	
		public IfcMaterialProperties(IfcIdentifier? __Name, IfcText? __Description, IfcProperty[] __Properties, IfcMaterialDefinition __Material)
			: base(__Name, __Description, __Properties)
		{
			this.Material = __Material;
		}
	
	
	}
	
}
