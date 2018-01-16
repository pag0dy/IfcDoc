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
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralLoadResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	[Guid("d755201f-41e5-41f3-b37c-30c473853a22")]
	public partial class IfcRelConnectsStructuralActivity : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcStructuralActivityAssignmentSelect _RelatingElement;
	
		[DataMember(Order=1)] 
		[XmlElement]
		[Required()]
		IfcStructuralActivity _RelatedStructuralActivity;
	
	
		[Description("Reference to a structural item or element to which the specified activity is appl" +
	    "ied.")]
		public IfcStructuralActivityAssignmentSelect RelatingElement { get { return this._RelatingElement; } set { this._RelatingElement = value;} }
	
		[Description("Reference to a structural activity which is acting upon the specified structural " +
	    "item or element.")]
		public IfcStructuralActivity RelatedStructuralActivity { get { return this._RelatedStructuralActivity; } set { this._RelatedStructuralActivity = value;} }
	
	
	}
	
}
