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
	[Guid("c715b91e-2c57-4166-9e0b-694da8b97ac6")]
	public partial class IfcContextDependentUnit : IfcNamedUnit,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcResourceObjectSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
		[InverseProperty("RelatedResourceObjects")] 
		ISet<IfcExternalReferenceRelationship> _HasExternalReference = new HashSet<IfcExternalReferenceRelationship>();
	
	
		[Description("The word, or group of words, by which the context dependent unit is referred to.")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("Reference to external information, e.g. library, classification, or document info" +
	    "rmation, which is associated with the context dependent unit.\r\n<blockquote class" +
	    "=\"change-ifc2x4\">IFC4 CHANGE New inverse attribute</blockquote>")]
		public ISet<IfcExternalReferenceRelationship> HasExternalReference { get { return this._HasExternalReference; } }
	
	
	}
	
}
