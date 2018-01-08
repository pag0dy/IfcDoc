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
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcTimeSeriesResource
{
	[Guid("247d10b2-f345-453b-b7cd-87e9bd8192f8")]
	public partial class IfcTimeSeriesReferenceRelationship
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcTimeSeries _ReferencedTimeSeries;
	
		[DataMember(Order=1)] 
		[Required()]
		ISet<IfcDocumentSelect> _TimeSeriesReferences = new HashSet<IfcDocumentSelect>();
	
	
		public IfcTimeSeries ReferencedTimeSeries { get { return this._ReferencedTimeSeries; } set { this._ReferencedTimeSeries = value;} }
	
		public ISet<IfcDocumentSelect> TimeSeriesReferences { get { return this._TimeSeriesReferences; } }
	
	
	}
	
}
