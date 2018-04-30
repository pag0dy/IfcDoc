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

namespace BuildingSmart.IFC.IfcPropertyResource
{
	public partial class IfcPropertyReferenceValue : IfcSimpleProperty
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Description of the use of the referenced value within the property.")]
		public IfcLabel? UsageName { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Reference to another entity through one of the select types in IfcObjectReferenceSelect.")]
		[Required()]
		public IfcObjectReferenceSelect PropertyReference { get; set; }
	
	
		public IfcPropertyReferenceValue(IfcIdentifier __Name, IfcText? __Description, IfcLabel? __UsageName, IfcObjectReferenceSelect __PropertyReference)
			: base(__Name, __Description)
		{
			this.UsageName = __UsageName;
			this.PropertyReference = __PropertyReference;
		}
	
	
	}
	
}
