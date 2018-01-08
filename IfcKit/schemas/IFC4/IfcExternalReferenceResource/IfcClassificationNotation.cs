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
	[Guid("54f9c8f1-3d9f-4e33-b7a4-8f397eb5f490")]
	public partial class IfcClassificationNotation :
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcClassificationNotationSelect
	{
		[DataMember(Order=0)] 
		[Required()]
		ISet<IfcClassificationNotationFacet> _NotationFacets = new HashSet<IfcClassificationNotationFacet>();
	
	
		[Description("Alphanumeric characters in defined groups from which the classification notation " +
	    "is derived.\r\n")]
		public ISet<IfcClassificationNotationFacet> NotationFacets { get { return this._NotationFacets; } }
	
	
	}
	
}
