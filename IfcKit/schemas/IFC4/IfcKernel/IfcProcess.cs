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
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProcessExtension;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	[Guid("f56a4e45-de47-49a7-83d1-3628609eb4f3")]
	public abstract partial class IfcProcess : IfcObject,
		BuildingSmart.IFC.IfcKernel.IfcProcessSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcIdentifier? _Identification;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _LongDescription;
	
		[InverseProperty("RelatingProcess")] 
		ISet<IfcRelSequence> _IsPredecessorTo = new HashSet<IfcRelSequence>();
	
		[InverseProperty("RelatedProcess")] 
		ISet<IfcRelSequence> _IsSuccessorFrom = new HashSet<IfcRelSequence>();
	
		[InverseProperty("RelatingProcess")] 
		ISet<IfcRelAssignsToProcess> _OperatesOn = new HashSet<IfcRelAssignsToProcess>();
	
	
		[Description("<EPM-HTML>\r\n    An identifying designation given to a process or activity.\r\n    I" +
	    "t is the identifier at the occurrence level. \r\n    <blockquote class=\"change-ifc" +
	    "2x4\">IFC4 CHANGE  Attribute promoted from subtypes.</blockquote>\r\n</EPM-HTML>")]
		public IfcIdentifier? Identification { get { return this._Identification; } set { this._Identification = value;} }
	
		[Description("<EPM-HTML>\r\nAn extended description or narrative that may be provided.\r\n<blockquo" +
	    "te class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribute.</blockquote>\r\n</EPM-HT" +
	    "ML>")]
		public IfcText? LongDescription { get { return this._LongDescription; } set { this._LongDescription = value;} }
	
		[Description("<EPM-HTML>\r\nDependency between two activities, it refers to the subsequent activi" +
	    "ty for which this activity is the predecessor. The link between two activities c" +
	    "an include a link type and a lag time. \r\n</EPM-HTML>")]
		public ISet<IfcRelSequence> IsPredecessorTo { get { return this._IsPredecessorTo; } }
	
		[Description("<EPM-HTML>\r\nDependency between two activities, it refers to the previous activity" +
	    " for which this activity is the successor. The link between two activities can i" +
	    "nclude a link type and a lag time. \r\n</EPM-HTML>")]
		public ISet<IfcRelSequence> IsSuccessorFrom { get { return this._IsSuccessorFrom; } }
	
		[Description("<EPM-HTML>\r\nSet of relationships to other objects, e.g. products, processes, cont" +
	    "rols, resources or actors, that are operated on by the process.\r\n</EPM-HTML>")]
		public ISet<IfcRelAssignsToProcess> OperatesOn { get { return this._OperatesOn; } }
	
	
	}
	
}
