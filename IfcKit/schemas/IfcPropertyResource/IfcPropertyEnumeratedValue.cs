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
	public partial class IfcPropertyEnumeratedValue : IfcSimpleProperty
	{
		[DataMember(Order = 0)] 
		[Description("Enumeration values, which shall be listed in the referenced <em>IfcPropertyEnumeration</em>, if such a reference is provided.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The attribute has been made optional with upward compatibility for file based exchange.</blockquote>")]
		[MinLength(1)]
		public IList<IfcValue> EnumerationValues { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlElement]
		[Description("Enumeration from which a enumeration value has been selected. The referenced enumeration also establishes the unit of the enumeration value.")]
		public IfcPropertyEnumeration EnumerationReference { get; set; }
	
	
		public IfcPropertyEnumeratedValue(IfcIdentifier __Name, IfcText? __Description, IfcValue[] __EnumerationValues, IfcPropertyEnumeration __EnumerationReference)
			: base(__Name, __Description)
		{
			this.EnumerationValues = new List<IfcValue>(__EnumerationValues);
			this.EnumerationReference = __EnumerationReference;
		}
	
	
	}
	
}
