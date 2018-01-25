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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	[Guid("658c5ceb-e16f-4dd0-9898-734a59492901")]
	public partial class IfcClassificationReference : IfcExternalReference,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcClassificationNotationSelect
	{
		[DataMember(Order=0)] 
		IfcClassification _ReferencedSource;
	
	
		[Description("The classification system or source that is referenced.")]
		public IfcClassification ReferencedSource { get { return this._ReferencedSource; } set { this._ReferencedSource = value;} }
	
	
	}
	
}
