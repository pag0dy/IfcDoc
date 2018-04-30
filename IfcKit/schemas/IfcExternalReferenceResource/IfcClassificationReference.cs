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
	public partial class IfcClassificationReference : IfcExternalReference,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcClassificationNotationSelect
	{
		[DataMember(Order = 0)] 
		[Description("The classification system or source that is referenced.")]
		public IfcClassification ReferencedSource { get; set; }
	
	
		public IfcClassificationReference(IfcLabel? __Location, IfcIdentifier? __ItemReference, IfcLabel? __Name, IfcClassification __ReferencedSource)
			: base(__Location, __ItemReference, __Name)
		{
			this.ReferencedSource = __ReferencedSource;
		}
	
	
	}
	
}
