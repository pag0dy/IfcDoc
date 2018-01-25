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
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProfilePropertyResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcQuantityResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcSharedBldgServiceElements;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcStructuralElementsDomain;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("310ebb6d-e2de-43c8-bbcb-546be2a7ed6f")]
	public partial class IfcCovering : IfcBuildingElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcCoveringTypeEnum? _PredefinedType;
	
		[InverseProperty("RelatedCoverings")] 
		ISet<IfcRelCoversSpaces> _CoversSpaces = new HashSet<IfcRelCoversSpaces>();
	
		[InverseProperty("RelatedCoverings")] 
		ISet<IfcRelCoversBldgElements> _Covers = new HashSet<IfcRelCoversBldgElements>();
	
	
		[Description("Predefined types to define the particular type of the covering. There may be prop" +
	    "erty set definitions available for each predefined type.")]
		public IfcCoveringTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		public ISet<IfcRelCoversSpaces> CoversSpaces { get { return this._CoversSpaces; } }
	
		[Description("<EPM-HTML>\r\nReference to the objectified relationship that handles the relationsh" +
	    "ip of the covering to the covered space.\r\n</EPM-HTML>\r\n")]
		public ISet<IfcRelCoversBldgElements> Covers { get { return this._Covers; } }
	
	
	}
	
}
