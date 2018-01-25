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

using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;

namespace BuildingSmart.IFC.IfcMeasureResource
{
	[Guid("7d4b1cf1-345c-456d-9199-c2fc2e7e94f0")]
	public partial class IfcConversionBasedUnit : IfcNamedUnit,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcResourceObjectSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
		[DataMember(Order=1)] 
		[XmlElement]
		[Required()]
		IfcMeasureWithUnit _ConversionFactor;
	
		[InverseProperty("RelatedResourceObjects")] 
		ISet<IfcExternalReferenceRelationship> _HasExternalReference = new HashSet<IfcExternalReferenceRelationship>();
	
	
		[Description("The word, or group of words, by which the conversion based unit is referred to.")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("The physical quantity from which the converted unit is derived.")]
		public IfcMeasureWithUnit ConversionFactor { get { return this._ConversionFactor; } set { this._ConversionFactor = value;} }
	
		[Description("Reference to external information, e.g. library, classification, or document info" +
	    "rmation, which is associated with the conversion-based unit.\r\n<blockquote class=" +
	    "\"change-ifc2x4\">IFC4 CHANGE New inverse attribute.</blockquote>")]
		public ISet<IfcExternalReferenceRelationship> HasExternalReference { get { return this._HasExternalReference; } }
	
	
	}
	
}
