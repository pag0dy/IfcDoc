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
	[Guid("f788d9ab-8d24-4c35-8520-678d52de6938")]
	public partial class IfcRelConnectsStructuralActivity : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcStructuralActivityAssignmentSelect _RelatingElement;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcStructuralActivity _RelatedStructuralActivity;
	
	
		[Description("Reference to an instance of IfcStructuralItem or IfcBuildingElement (or its subcl" +
	    "asses) to which the specified action is applied.")]
		public IfcStructuralActivityAssignmentSelect RelatingElement { get { return this._RelatingElement; } set { this._RelatingElement = value;} }
	
		[Description("Reference to an instance of IfcStructuralActivity (or its subclasses) which is ac" +
	    "ting upon the specified structural element (represented by a respective structur" +
	    "al representation entity). ")]
		public IfcStructuralActivity RelatedStructuralActivity { get { return this._RelatedStructuralActivity; } set { this._RelatedStructuralActivity = value;} }
	
	
	}
	
}
