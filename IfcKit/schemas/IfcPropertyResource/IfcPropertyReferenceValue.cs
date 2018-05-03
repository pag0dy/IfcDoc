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

using BuildingSmart.IFC.IfcApprovalResource;
using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcPropertyResource
{
	public partial class IfcPropertyReferenceValue : IfcSimpleProperty
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Description of the use of the referenced value within the property. It is a descriptive text that may hold an expression or other additional information.")]
		public IfcText? UsageName { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Reference to another property entity through one of the select types in the <em>IfcObjectReferenceSelect</em>.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The attribute has been made optional with upward compatibility for file based exchange.</blockquote>")]
		public IfcObjectReferenceSelect PropertyReference { get; set; }
	
	
		public IfcPropertyReferenceValue(IfcIdentifier __Name, IfcText? __Description, IfcText? __UsageName, IfcObjectReferenceSelect __PropertyReference)
			: base(__Name, __Description)
		{
			this.UsageName = __UsageName;
			this.PropertyReference = __PropertyReference;
		}
	
	
	}
	
}
