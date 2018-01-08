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
	[Guid("8ee8ef7b-68ac-46bb-8c28-b6f508eeb0ab")]
	public partial class IfcRelDefinesByTemplate : IfcRelDefines
	{
		[DataMember(Order=0)] 
		[Required()]
		ISet<IfcPropertySetDefinition> _RelatedPropertySets = new HashSet<IfcPropertySetDefinition>();
	
		[DataMember(Order=1)] 
		[XmlElement("IfcPropertySetTemplate")]
		[Required()]
		IfcPropertySetTemplate _RelatingTemplate;
	
	
		[Description("One or many property sets or quantity sets that obtain their definitions from the" +
	    " single property set template.")]
		public ISet<IfcPropertySetDefinition> RelatedPropertySets { get { return this._RelatedPropertySets; } }
	
		[Description("Property set template that provides the common definition of related property set" +
	    "s. ")]
		public IfcPropertySetTemplate RelatingTemplate { get { return this._RelatingTemplate; } set { this._RelatingTemplate = value;} }
	
	
	}
	
}
