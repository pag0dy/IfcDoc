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
	[Guid("e9e318da-ceb2-4700-9c42-17311e5549b1")]
	public partial class IfcComplexPropertyTemplate : IfcPropertyTemplate
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _UsageName;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcComplexPropertyTemplateTypeEnum? _TemplateType;
	
		[DataMember(Order=2)] 
		ISet<IfcPropertyTemplate> _HasPropertyTemplates = new HashSet<IfcPropertyTemplate>();
	
	
		public IfcLabel? UsageName { get { return this._UsageName; } set { this._UsageName = value;} }
	
		public IfcComplexPropertyTemplateTypeEnum? TemplateType { get { return this._TemplateType; } set { this._TemplateType = value;} }
	
		[Description("Reference to a set of property templates. It should only be provided, if the <em>" +
	    "PropertyType</em> is set to <small>COMPLEX</small>.")]
		public ISet<IfcPropertyTemplate> HasPropertyTemplates { get { return this._HasPropertyTemplates; } }
	
	
	}
	
}
