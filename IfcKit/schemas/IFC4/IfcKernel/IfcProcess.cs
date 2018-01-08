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
	
	
		[Description("    An identifying designation given to a process or activity.\r\n    It is the ide" +
	    "ntifier at the occurrence level. \r\n    <blockquote class=\"change-ifc2x4\">IFC4 CH" +
	    "ANGE  Attribute promoted from subtypes.</blockquote>")]
		public IfcIdentifier? Identification { get { return this._Identification; } set { this._Identification = value;} }
	
		[Description("An extended description or narrative that may be provided.\r\n<blockquote class=\"ch" +
	    "ange-ifc2x4\">IFC4 CHANGE&nbsp; New attribute.</blockquote>")]
		public IfcText? LongDescription { get { return this._LongDescription; } set { this._LongDescription = value;} }
	
		[Description("Dependency between two activities, it refers to the subsequent activity for which" +
	    " this activity is the predecessor. The link between two activities can include a" +
	    " link type and a lag time. ")]
		public ISet<IfcRelSequence> IsPredecessorTo { get { return this._IsPredecessorTo; } }
	
		[Description("Dependency between two activities, it refers to the previous activity for which t" +
	    "his activity is the successor. The link between two activities can include a lin" +
	    "k type and a lag time. ")]
		public ISet<IfcRelSequence> IsSuccessorFrom { get { return this._IsSuccessorFrom; } }
	
		[Description("Set of relationships to other objects, e.g. products, processes, controls, resour" +
	    "ces or actors, that are operated on by the process.")]
		public ISet<IfcRelAssignsToProcess> OperatesOn { get { return this._OperatesOn; } }
	
	
	}
	
}
