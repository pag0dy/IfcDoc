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
	[Guid("0005340c-4472-4a05-832a-cd044bdf99a9")]
	public partial class IfcRelOverridesProperties : IfcRelDefinesByProperties
	{
		[DataMember(Order=0)] 
		[Required()]
		ISet<IfcProperty> _OverridingProperties = new HashSet<IfcProperty>();
	
	
		[Description("A property set, which contains those properties, that have a different value for " +
	    "the subset of objects.")]
		public ISet<IfcProperty> OverridingProperties { get { return this._OverridingProperties; } }
	
	
	}
	
}
