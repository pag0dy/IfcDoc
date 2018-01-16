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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfilePropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralLoadResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	[Guid("b3ecec25-6d42-49a2-bd7d-e64a12cc90ea")]
	public partial class IfcRelConnectsWithEccentricity : IfcRelConnectsStructuralMember
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcConnectionGeometry _ConnectionConstraint;
	
	
		[Description("<EPM-HTML>\r\nThe connection constraint explicitly states the eccentricity between " +
	    "a structural element and a structural connection, either given by two point (use" +
	    "d to calculate the eccentricity), or by explicit x, y, and z offsets.\r\n</EPM-HTM" +
	    "L>")]
		public IfcConnectionGeometry ConnectionConstraint { get { return this._ConnectionConstraint; } set { this._ConnectionConstraint = value;} }
	
	
	}
	
}
