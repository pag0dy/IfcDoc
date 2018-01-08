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
	[Guid("638492f3-23b3-4ca5-a78e-9370f5343f65")]
	public abstract partial class IfcTypeProcess : IfcTypeObject,
		BuildingSmart.IFC.IfcKernel.IfcProcessSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcIdentifier? _Identification;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _LongDescription;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _ProcessType;
	
		[InverseProperty("RelatingProcess")] 
		ISet<IfcRelAssignsToProcess> _OperatesOn = new HashSet<IfcRelAssignsToProcess>();
	
	
		[Description("<EPM-HTML>\r\nAn identifying designation given to a process type.\r\n</EPM-HTML>")]
		public IfcIdentifier? Identification { get { return this._Identification; } set { this._Identification = value;} }
	
		[Description("<EPM-HTML>\r\nAn long description, or text, describing the activity in detail.\r\n<bl" +
	    "ockquote class=\"note\">NOTE&nbsp; The inherited <em>SELF\\IfcRoot.Description</em>" +
	    " attribute is used as the short description.</blockquote>\r\n</EPM-HTML>")]
		public IfcText? LongDescription { get { return this._LongDescription; } set { this._LongDescription = value;} }
	
		[Description(@"<EPM-HTML>
	The type denotes a particular type that indicates the process further. The use has to be established at the level of instantiable subtypes. In particular it holds the user defined type, if the enumeration of the attribute 'PredefinedType' is set to USERDEFINED. 
	</EPM-HTML>")]
		public IfcLabel? ProcessType { get { return this._ProcessType; } set { this._ProcessType = value;} }
	
		[Description("<EPM-HTML>\r\nSet of relationships to other objects, e.g. products, processes, cont" +
	    "rols, resources or actors that are operated on by the process type.\r\n<blockquote" +
	    " class=\"history\">HISTORY  New inverse relationship in IFC4.</blockquote>\r\n</EPM-" +
	    "HTML>")]
		public ISet<IfcRelAssignsToProcess> OperatesOn { get { return this._OperatesOn; } }
	
	
	}
	
}
