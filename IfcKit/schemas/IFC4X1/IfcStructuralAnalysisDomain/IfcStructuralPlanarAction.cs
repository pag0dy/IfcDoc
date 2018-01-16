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
	[Guid("96689b85-5ea5-4eee-8eef-57a2e8f5c7bb")]
	public partial class IfcStructuralPlanarAction : IfcStructuralAction
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcProjectedOrTrueLengthEnum _ProjectedOrTrue;
	
	
		[Description(@"Defines if the load values are given by using the length of the member on which they act (true length) or by using the projected length resulting from the loaded member and the global project coordinate system. It is only considered if the global project coordinate system is used, and if the action is of type IfcStructuralLinearAction or IfcStructuralPlanarAction. ")]
		public IfcProjectedOrTrueLengthEnum ProjectedOrTrue { get { return this._ProjectedOrTrue; } set { this._ProjectedOrTrue = value;} }
	
	
	}
	
}
