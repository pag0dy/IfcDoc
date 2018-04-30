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
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	public abstract partial class IfcExternalReference :
		BuildingSmart.IFC.IfcPresentationOrganizationResource.IfcLightDistributionDataSourceSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Location, where the external source (classification, document or library). This can be either human readable or computer interpretable. For electronic location normally given as an URL location string, however other ways of accessing external references may be established in an application scenario.  ")]
		public IfcLabel? Location { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Identifier for the referenced item in the external source (classification, document or library). The internal reference can provide a computer interpretable pointer into electronic source.")]
		public IfcIdentifier? ItemReference { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Optional name to further specify the reference. It can provide a human readable identifier (which does not necessarily need to have a counterpart in the internal structure of the document).")]
		public IfcLabel? Name { get; set; }
	
	
		protected IfcExternalReference(IfcLabel? __Location, IfcIdentifier? __ItemReference, IfcLabel? __Name)
		{
			this.Location = __Location;
			this.ItemReference = __ItemReference;
			this.Name = __Name;
		}
	
	
	}
	
}
