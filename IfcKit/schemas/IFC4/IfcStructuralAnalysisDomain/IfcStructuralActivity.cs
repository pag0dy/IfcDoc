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
	[Guid("b7ecfe53-434a-4afb-b963-301a02d20c51")]
	public abstract partial class IfcStructuralActivity : IfcProduct
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcStructuralLoad _AppliedLoad;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcGlobalOrLocalEnum _GlobalOrLocal;
	
		[InverseProperty("RelatedStructuralActivity")] 
		IfcRelConnectsStructuralActivity _AssignedToStructuralItem;
	
	
		[Description("Reference to the load resource, which is used to define the load type, direction " +
	    "and load values. The specified load types are provided in the IfcStructuralLoadR" +
	    "esource presented at the end of this document.")]
		public IfcStructuralLoad AppliedLoad { get { return this._AppliedLoad; } set { this._AppliedLoad = value;} }
	
		[Description("Indicates if the load values are defined by using the local  coordinate system or" +
	    " the global project coordinate system.")]
		public IfcGlobalOrLocalEnum GlobalOrLocal { get { return this._GlobalOrLocal; } set { this._GlobalOrLocal = value;} }
	
		[Description("References to the IfcRelConnectsStructuralActivity relationship by which activiti" +
	    "es can be associated to structural representations.")]
		public IfcRelConnectsStructuralActivity AssignedToStructuralItem { get { return this._AssignedToStructuralItem; } set { this._AssignedToStructuralItem = value;} }
	
	
	}
	
}
