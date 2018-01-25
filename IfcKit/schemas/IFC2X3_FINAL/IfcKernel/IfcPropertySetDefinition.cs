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
	[Guid("bd84994e-d30e-4142-b97b-0349178120da")]
	public abstract partial class IfcPropertySetDefinition : IfcPropertyDefinition
	{
		[InverseProperty("RelatingPropertyDefinition")] 
		ISet<IfcRelDefinesByProperties> _PropertyDefinitionOf = new HashSet<IfcRelDefinesByProperties>();
	
		[InverseProperty("HasPropertySets")] 
		ISet<IfcTypeObject> _DefinesType = new HashSet<IfcTypeObject>();
	
	
		[Description(@"Reference to the relation to one or many objects that are characterized by the property definition. The reference may be omitted, if the property definition is used to define a style library and no instances, to which the particular style of property set is associated, exist yet.")]
		public ISet<IfcRelDefinesByProperties> PropertyDefinitionOf { get { return this._PropertyDefinitionOf; } }
	
		[Description("The property style to which the property set might belong.")]
		public ISet<IfcTypeObject> DefinesType { get { return this._DefinesType; } }
	
	
	}
	
}
