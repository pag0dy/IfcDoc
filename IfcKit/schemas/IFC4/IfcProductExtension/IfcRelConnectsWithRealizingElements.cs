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
	[Guid("d323c3ef-322b-43ec-85c2-f5eab3b2ec47")]
	public partial class IfcRelConnectsWithRealizingElements : IfcRelConnectsElements
	{
		[DataMember(Order=0)] 
		[Required()]
		ISet<IfcElement> _RealizingElements = new HashSet<IfcElement>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _ConnectionType;
	
	
		[Description("Defines the elements that realize a connection relationship.")]
		public ISet<IfcElement> RealizingElements { get { return this._RealizingElements; } }
	
		[Description("The type of the connection given for informal purposes, it may include labels, li" +
	    "ke \'joint\', \'rigid joint\', \'flexible joint\', etc.")]
		public IfcLabel? ConnectionType { get { return this._ConnectionType; } set { this._ConnectionType = value;} }
	
	
	}
	
}
