// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcPresentationDimensioningResource
{
	public partial class IfcDimensionCurveTerminator : IfcTerminatorSymbol
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Role of the dimension curve terminator within a dimension curve (being either an origin or target).")]
		[Required()]
		public IfcDimensionExtentUsage Role { get; set; }
	
	
		public IfcDimensionCurveTerminator(IfcRepresentationItem __Item, IfcPresentationStyleAssignment[] __Styles, IfcLabel? __Name, IfcAnnotationCurveOccurrence __AnnotatedCurve, IfcDimensionExtentUsage __Role)
			: base(__Item, __Styles, __Name, __AnnotatedCurve)
		{
			this.Role = __Role;
		}
	
	
	}
	
}
