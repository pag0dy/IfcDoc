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
	[Guid("2ef4dae0-8e0d-4c3e-a179-bf7d2f279492")]
	public abstract partial class IfcContext : IfcObjectDefinition
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _ObjectType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _LongName;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _Phase;
	
		[DataMember(Order=3)] 
		ISet<IfcRepresentationContext> _RepresentationContexts = new HashSet<IfcRepresentationContext>();
	
		[DataMember(Order=4)] 
		[XmlElement("IfcUnitAssignment")]
		IfcUnitAssignment _UnitsInContext;
	
		[InverseProperty("RelatedObjects")] 
		[XmlElement]
		ISet<IfcRelDefinesByProperties> _IsDefinedBy = new HashSet<IfcRelDefinesByProperties>();
	
		[InverseProperty("RelatingContext")] 
		[XmlElement]
		ISet<IfcRelDeclares> _Declares = new HashSet<IfcRelDeclares>();
	
	
		[Description(@"The object type denotes a particular type that indicates the object further. The use has to be established at the level of instantiable subtypes. 
	<blockquote class=""note"">
	NOTE&nbsp; Subtypes of <em>IfcContext</em> do not introduce a <em>PredefinedType</em> attribute, therefore the usage of <em>ObjectType</em> is not bound to the selection of USERDEFINED within the <em>PredefinedType</em> enumaration.
	</blockquote>")]
		public IfcLabel? ObjectType { get { return this._ObjectType; } set { this._ObjectType = value;} }
	
		[Description("Long name for the context as used for reference purposes.")]
		public IfcLabel? LongName { get { return this._LongName; } set { this._LongName = value;} }
	
		[Description("Current project phase, or life-cycle phase of this project. Applicable values hav" +
	    "e to be agreed upon by view definitions or implementer agreements. \r\n")]
		public IfcLabel? Phase { get { return this._Phase; } set { this._Phase = value;} }
	
		[Description(@"Context of the representations used within the context. When the context is a project and it includes shape representations for its components, one or several geometric representation contexts need to be included that define e.g. the world coordinate system, the coordinate space dimensions, and/or the precision factor.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The attribute has been changed to be optional. Change made with upward compatibility for file based exchange.</blockquote>")]
		public ISet<IfcRepresentationContext> RepresentationContexts { get { return this._RepresentationContexts; } }
	
		[Description("Units globally assigned to measure types used within the context.\r\n<blockquote cl" +
	    "ass=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The attribute has been changed to be optio" +
	    "nal. Change made with upward compatibility for file based exchange.</blockquote>" +
	    "")]
		public IfcUnitAssignment UnitsInContext { get { return this._UnitsInContext; } set { this._UnitsInContext = value;} }
	
		[Description(@"Set of relationships to property set definitions attached to this context. Those statically or dynamically defined properties contain alphanumeric information content that further defines the context. 
	<blockquote class=""change-ifc2x4"">
	IFC4 CHANGE&nbsp; The data type has been changed from <em>IfcRelDefines</em> to <em>IfcRelDefinesByProperties</em> with upward compatibility for file based exchange.
	</blockquote>")]
		public ISet<IfcRelDefinesByProperties> IsDefinedBy { get { return this._IsDefinedBy; } }
	
		[Description(@"Reference to the <em>IfcRelDeclares</em> relationship that assigns the uppermost entities of includes hierarchies to this context instance.
	<blockquote class=""note"">NOTE&nbsp; The spatial hiearchy is assigned to <em>IfcProject</em> using the <em>IfcRelAggregates</em> relationship. This is a single exception due to compatibility reasons with earlier releases.</blockquote>")]
		public ISet<IfcRelDeclares> Declares { get { return this._Declares; } }
	
	
	}
	
}
