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
using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	[Guid("ebe9bf08-62e1-4ce5-8869-861d49604fdf")]
	public abstract partial class IfcRelAssigns : IfcRelationship
	{
		[DataMember(Order=0)] 
		[Required()]
		ISet<IfcObjectDefinition> _RelatedObjects = new HashSet<IfcObjectDefinition>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcObjectTypeEnum? _RelatedObjectsType;
	
	
		[Description("Related objects, which are assigned to a single object. The type of the single (o" +
	    "r relating) object is defined in the subtypes of IfcRelAssigns.")]
		public ISet<IfcObjectDefinition> RelatedObjects { get { return this._RelatedObjects; } }
	
		[Description("Particular type of the assignment relationship. It can constrain the applicable o" +
	    "bject types, used within the role of RelatedObjects.\r\n")]
		public IfcObjectTypeEnum? RelatedObjectsType { get { return this._RelatedObjectsType; } set { this._RelatedObjectsType = value;} }
	
	
	}
	
}
